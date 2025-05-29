namespace csharp_kafka.Consumer.Configurations
{
    public class AppSetting
    {
        public Logging Logging { get; set; }
        public Kafka Kafka { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Kafka
    {
        public string BootstrapServers { get; set; }
    }
}
