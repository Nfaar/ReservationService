using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReservationService.EventProcessing;

namespace ReservationService.AsyncDataServices
{
    public class MessageBusSubscriber : BackgroundService
    {
        private readonly IConfiguration configuration;
        private IEventProcessor eventProcessor;
        private IConnection connection;
        private IModel channel;
        private string queueName;

        public MessageBusSubscriber(
            IConfiguration configuration, IEventProcessor eventProcessor)
        {
            this.configuration = configuration;
            this.eventProcessor = eventProcessor;

            InitializeRabbitMQ();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = this.configuration["RabbitMQHost"], Port = int.Parse(this.configuration["RabbitMQPort"]) };

            this.connection = factory.CreateConnection();
            this.channel = this.connection.CreateModel();
            this.channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            this.queueName = this.channel.QueueDeclare().QueueName;
            this.channel.QueueBind(
                queue: this.queueName,
                exchange: "trigger",
                routingKey: "");

            System.Console.WriteLine("--> Listening on the Message Bus...");

            this.connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            System.Console.WriteLine("--> Connection Shutdown");
        }

        public override void Dispose()
        {
            if (this.channel.IsOpen)
            {
                this.channel.Close();
                this.connection.Close();
            }

            base.Dispose();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(this.channel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                System.Console.WriteLine("--> Event Received");

                var body = ea.Body;
                var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

                this.eventProcessor.ProcessEvent(notificationMessage);
            };

            this.channel.BasicConsume(queue: this.queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}