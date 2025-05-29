using Confluent.Kafka;
using csharp_kafka.Consumer.Configurations;
using Microsoft.Extensions.Options;

namespace csharp_kafka.Consumer.Services
{
    public class ConsumerService : BackgroundService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly ILogger<ConsumerService> _logger;
        private readonly AppSetting _appSetting;

        public ConsumerService(ILogger<ConsumerService> logger, IOptions<AppSetting> setting)
        {
            _logger = logger;
            _appSetting = setting.Value;

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = _appSetting.Kafka.BootstrapServers,
                GroupId = "ProductConsumerGroup",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe("ProductTopic");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken);

                    var message = consumeResult.Message.Value;

                    _logger.LogInformation($"Received inventory update: {message}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error processing Kafka message: {ex.Message}");
                }
            }
        }
    }
}
