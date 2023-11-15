// Behavioral Design Pattern Category : Observer pattern //

var xiaomi = new Product("Xiaomi Redmi 10", 1000);
var amazon = new Amazon();
var bedirhanObserver = new BedirhanObserver("Bedirhan Tong");

amazon.Register(bedirhanObserver, xiaomi);
amazon.NotifyByProductName("Xiaomi Redmi 10");

Console.ReadLine();



class Amazon
{
    private Dictionary<IObserver, Product> observerPairs = new(); 
    public void Register(IObserver observer,Product product) {
        observerPairs.Add(observer, product);
    }
    public void Unregister(IObserver observer) {
        observerPairs.Remove(observer);
    }

    public void NotifyByProductName(string ProductName)
    {
        foreach(var KeyValuePair in observerPairs)
        {
            if (KeyValuePair.Value.Name == ProductName)
            {
                KeyValuePair.Key.StockUpdate(KeyValuePair.Value);
            }
        }
    }

    public void NotifyAll()
    {
        foreach (var KeyValuePair in observerPairs)
        {
            KeyValuePair.Key.StockUpdate(KeyValuePair.Value);
        }
    }
}

interface IObserver
{
    void StockUpdate(Product product);
}

class BedirhanObserver : IObserver
{
    private String Name {  get; set; }
    public BedirhanObserver(String Name) {  this.Name = Name; }
    public BedirhanObserver() { }

    public void StockUpdate(Product product)
    {
        Console.WriteLine("Sayın "+ Name+" "+product.Name+" ürünü stoklarımıza gelmiştir.");
    }
}

class Product
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public Product() { }
    public Product(string Name, int Cost)
    {
        this.Name = Name;
        this.Cost = Cost;
    }
}