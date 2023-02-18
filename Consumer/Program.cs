using Confluent.Kafka;

namespace kafka_consumer
{
    public class Program
    {
        public static void Main()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(conf).Build();
            {
                consumer.Subscribe("test-topic");

                var cancelationToken = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cancelationToken.Cancel();
                };

                try
                {
                    var count = 0;
                    while (true){
                        try
                        {
                            var consume = consumer.Consume(cancelationToken.Token);
                            Console.WriteLine($"Consumed message '{consume.Value} at: '{consume.TopicPartitionOffset}' | {count++}'");
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                            throw;
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
            }
        }
    }
}