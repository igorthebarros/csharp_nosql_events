using Confluent.Kafka;

namespace kafka_producer
{
    public class Program
    {
        public static async Task Main()
        {
            var conf = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using var producer = new ProducerBuilder<Null, string>(conf).Build();
            {
                try
                {
                    var count = 0;

                    while (true)
                    {
                        var delivered = await producer.ProduceAsync("test-topic", new Message<Null, string> { Value = $"Test: {count++}" });
                        Console.WriteLine($"Produced message '{delivered.Value} at: '{delivered.TopicPartitionOffset}' | {count++}'");

                        Thread.Sleep(2000);
                    }
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
}