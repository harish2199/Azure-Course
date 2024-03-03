using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;

namespace EventHubsDemo
{
    class Program
    {
        private const string ehubNamespaceConnectionString = "Endpoint=sb://eventhubdemoharish.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=w4Hjy+6Gdfjn6M76s66MXkBvnEdhR0/6q+AEhEyNCFU=";
        private const string eventHubName = "my-telemetry";        

        static  async Task Main(string[] args)
        {
            // Read from the default consumer group: $Default
            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            // Create an event processor client to process events in the event hub
            var consumer= new EventHubConsumerClient(consumerGroup, ehubNamespaceConnectionString, eventHubName);

            Console.WriteLine("Waiting for messages...");

            while (true)  {
                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync())
                {
                    Console.WriteLine($"Message Received: {System.Text.Encoding.Default.GetString(partitionEvent.Data.Body.Span)}");                    
                }
            }  
        }        
    }
}
