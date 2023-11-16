


Console.WriteLine("AppDatagram");
AppDatagram appDatagram = new AppDatagram();
appDatagram.Send();
Console.WriteLine("---------------------");
Console.WriteLine("Use UDP layer");
UseUDP useUDP = new UseUDP(appDatagram);
useUDP.Send();
Console.WriteLine("---------------------");

Console.WriteLine("Use UseTCP layer");
UseTCP useTCP = new UseTCP(appDatagram);
useTCP.Send();

















// Component
interface IDatagram
{
    void Send();
}

// ConcreteComponent
class AppDatagram : IDatagram
{
    public void Send()
    {
        Console.WriteLine("IP datagram gönder.");
    }
}

// Decorator

class TransportLayerDecorator : IDatagram
{
    readonly IDatagram _datagram;

    public TransportLayerDecorator(IDatagram datagram)
    {
        _datagram = datagram;
    }

    virtual public void Send()
    {
        _datagram.Send();
    }
}

class UseTCP : TransportLayerDecorator
{
    public UseTCP(IDatagram datagram) : base(datagram)
    {
    }
    public override void Send()
    {
        base.Send();
        Console.WriteLine("TCP protokolü devreye sokuldu.");
    }
}

class UseUDP : TransportLayerDecorator
{
    public UseUDP(IDatagram datagram): base(datagram) { }
    public override void Send()
    {
        base.Send();
        Console.WriteLine("UDP protokolü devreye sokuldu.");
    }
}