using Confluent.Kafka;
using csharp_kafka.Producer.Configurations;
using Microsoft.Extensions.Options;

namespace csharp_kafka.Producer.Features.Product.CreateProduct;

public class CreateProductService
{
    private readonly AppSetting _appSetting;

    private readonly IProducer<Null, string> _producer;

    public CreateProductService(IOptions<AppSetting> setting)
    {
        _appSetting = setting.Value;

        var producerconfig = new ProducerConfig
        {
            BootstrapServers = _appSetting.Kafka.BootstrapServers,
            EnableIdempotence = true
        };

        _producer = new ProducerBuilder<Null, string>(producerconfig).Build();
    }

    public async Task ProduceAsync(string topic, string message)
    {
        try
        {
            var kafkamessage = new Message<Null, string> { Value = message, };

            await _producer.ProduceAsync(topic, kafkamessage);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
