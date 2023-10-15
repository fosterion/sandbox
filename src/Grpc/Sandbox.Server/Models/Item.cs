using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Server.Models;

public class Item
{
    public int Id { get; }
    public string Name { get; }
    public double Price { get; }
    public bool IsActual { get; }

    public Item(int id, string name, double price, bool isActual)
    {
        Id = id;
        Name = name;
        Price = price;
        IsActual = isActual;
    }
}
