using Grpc.Core;
using GrpcSandbox.Protos;
using GrpcSandbox.Server.Models;

namespace GrpcSandbox.Server.Services
{
    public class MarketService : Market.MarketBase
    {
        private readonly List<Item> _items;

        public MarketService()
        {
            _items = new List<Item>()
            {
                new Item(1, "Bread", 1.25, true),
                new Item(2, "Milk", 2.75, true),
                new Item(3, "Parrot", 1.59, false),
                new Item(4, "Potato", 0.99, true),
                new Item(5, "Onion", 1.25, false)
            };
        }

        public override Task<ItemReply> SingleItem(ItemRequest request,
            ServerCallContext context)
        {
            var item = _items.FirstOrDefault(_ => _.Id == request.Id);

            if (item is null)
                throw new NotImplementedException();

            return Task.FromResult(new ItemReply()
            {
                Name = item.Name,
                Price = item.Price,
                IsActual = item.IsActual
            });
        }

        public override async Task ActualItems(ActualItemsRequest request,
            IServerStreamWriter<ItemReply> responseStream,
            ServerCallContext context)
        {
            foreach (var item in _items.Where(_ => _.IsActual == request.IsActual))
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(new ItemReply()
                {
                    Name = item.Name,
                    Price = item.Price,
                    IsActual = item.IsActual
                });
            }
        }

        public override async Task AllItems(AllItemsRequest request,
            IServerStreamWriter<ItemReply> responseStream,
            ServerCallContext context)
        {
            foreach (var item in _items)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(new ItemReply()
                {
                    Name = item.Name,
                    Price = item.Price,
                    IsActual = item.IsActual
                });
            }
        }
    }
}
