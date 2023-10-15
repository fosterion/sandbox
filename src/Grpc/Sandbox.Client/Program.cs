using Grpc.Core;
using Grpc.Net.Client;
using Sandbox.Protos;

namespace Sandbox.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7295");
        var client = new Market.MarketClient(channel);

        await SingleItem(client);
        Console.WriteLine();
        await ActualItems(client, true);
        Console.WriteLine();
        await ActualItems(client, false);
        Console.WriteLine();
        await AllItems(client);

        Console.WriteLine("Done");
        Console.ReadKey();


    }

    private static async Task SingleItem(Market.MarketClient client)
    {
        var reply = await client.SingleItemAsync(new ItemRequest()
        {
            Id = 1
        });

        Console.WriteLine("Single item:");
        Console.WriteLine(BuildMessage(reply));
    }

    private static async Task ActualItems(Market.MarketClient client, bool isActual)
    {
        using (var call = client.ActualItems(new ActualItemsRequest() { IsActual = isActual }))
        {
            Console.WriteLine($"{GetStatus(isActual)} items:");
            while (await call.ResponseStream.MoveNext())
            {
                var currentItem = call.ResponseStream.Current;

                Console.WriteLine(BuildMessage(currentItem));
            }
        }
    }

    private static async Task AllItems(Market.MarketClient client)
    {
        using (var call = client.AllItems(new AllItemsRequest()))
        {
            Console.WriteLine("All items:");
            while (await call.ResponseStream.MoveNext())
            {
                var currentItem = call.ResponseStream.Current;

                Console.WriteLine(BuildMessage(currentItem));
            }
        }
    }

    private static string BuildMessage(ItemReply model)
        => $"Item <{model.Name}> costs ${model.Price}. This price is {GetStatus(model.IsActual)}.";

    private static string GetStatus(bool isActual)
        => isActual ? "Actual" : "Obsolete";
}
