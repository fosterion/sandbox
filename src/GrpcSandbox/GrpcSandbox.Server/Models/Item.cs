namespace GrpcSandbox.Server.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActual { get; set; }

        public Item(int id, string name, double price, bool isActual)
        {
            Id = id;
            Name = name;
            Price = price;
            IsActual = isActual;
        }
    }
}
