namespace ShopTDD;
using FluentAssertions;

public class UnitTest1
{
    [Fact]
    public void AddNothingToCart()
    {
        Cart cart = new Cart();
        cart.Add(null);
        cart.Total.Should().Be(0);
    }

    [Fact]
    public void AddProductAToCart()
    {
        Cart cart = new Cart();
        cart.Add(new Product { Name = 'A', Price = 10 });
        cart.Total.Should().Be(10);
    }

    [Fact]
    public void AddProductBToCart()
    {
        Cart cart = new Cart();
        cart.Add(new Product { Name = 'B', Price = 20 });
        cart.Total.Should().Be(20);
    }

    [Fact]
    public void AddProductCToCart()
    {
        Cart cart = new Cart();
        cart.Add(new Product { Name = 'C', Price = 30 });
        cart.Total.Should().Be(30);
    }

    [Fact]
    public void AddProductAToCart3Times()
    {
        Cart cart = new Cart();

        cart.Add(new Product { Name = 'A', Price = 10 });
        cart.Add(new Product { Name = 'A', Price = 10 });
        cart.Add(new Product { Name = 'A', Price = 10 });
        cart.Total.Should().Be(25);
    }

    [Fact]
    public void AddProductBToCart2Times()
    {
        Cart cart = new Cart();

        cart.Add(new Product { Name = 'B', Price = 20 });
        cart.Add(new Product { Name = 'B', Price = 20 });
        cart.Total.Should().Be(30);
    }

    [Fact]
    public void AddProductCToCart3Times()
    {
        Cart cart = new Cart();

        cart.Add(new Product { Name = 'C', Price = 30 });
        cart.Add(new Product { Name = 'C', Price = 30 });
        cart.Add(new Product { Name = 'C', Price = 30 });
        System.Console.WriteLine(cart.Total);
        cart.Total.Should().Be(90);

    }
}


public class Cart
{
    public int Total { get; set; } = 0;
    private Dictionary<char, int> Items = new Dictionary<char, int>();
    private Dictionary<char, int> Rule = new Dictionary<char, int>();
    private Dictionary<char, int> Discount = new Dictionary<char, int>();
    public Cart()
    {
        Rule.Add('A', 3);
        Rule.Add('B', 2);
        Rule.Add('C', 1);
        Discount.Add('A', 5);
        Discount.Add('B', 10);
        Discount.Add('C', 0);
    }
    public void Add(Product? product)
    {
        if (product != null)
        {
            if (!Items.ContainsKey(product.Name)) Items.Add(product.Name, 0);
            Items[product.Name] += 1;
        }
        Total += (int)(product?.Price ?? 0);
        if (product != null && Items[product.Name] == Rule[product.Name])
        {
            Total -= Discount[product.Name];
        }
    }

}

public class Product
{
    public char Name { get; set; }
    public int Price { get; set; }
}
