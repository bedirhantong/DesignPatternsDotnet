namespace DesignPatterns.DecoratorPattern.Computers
{
    public class Computer
    {
        public void Start()
        {
            Console.WriteLine($"{GetType().Name} is starting");
        }

        public void ShutDown() {
            Console.WriteLine($"{GetType().Name} is shutting down");
        }
    }

    public class Laptop : Computer 
    {
        public void OpenLid()
        {
            Console.WriteLine($"{GetType().Name}'s is lid is opening");
        }

        public void CloseLid()
        {
            Console.WriteLine($"{GetType().Name}'s lid is closing");
        }
    }


    public class LaptopDecorator : Laptop
    {
        public virtual void OpenLidDecorator()
        {
            base.CloseLid();
        }

        public virtual void CloseLidDecorator()
        {
            base.OpenLid();
        }
    }

    public class AsusLaptop : LaptopDecorator
    {

        public override void CloseLidDecorator()
        {
            // do something
            base.CloseLid();
            // do something
            Console.WriteLine("Asus laptop is sleeping");
        }
    }

    public class MacbookPro : LaptopDecorator
    {
        public override void OpenLidDecorator()
        {
            Console.WriteLine("Apple icon is at the center of the screen.");
            base.OpenLid();
        }
    }

    public class DellLaptop : Laptop
    {

    }

}
