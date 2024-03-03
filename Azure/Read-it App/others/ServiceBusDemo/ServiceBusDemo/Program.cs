using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.Messaging.ServiceBus;

namespace ServiceBusDemo
{
    class Program
    {
        public static string connectionString = "Endpoint=sb://servicebusdemoharish.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=qHW6yuhAtspKM9bElgKihjFi9FQgeQkSe+ASbIRYDfo=";
        public static string queueName = "my-items";

        public static async Task Main(string[] args)
        {    
            
            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            // Send message
            await SendMessageAsync();

            Console.Read();
        }

        static async Task SendMessageAsync()
        {
            // create a Service Bus client 
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage("Test Message");

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }
        }          
    }
}
