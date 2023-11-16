
// PlayStationFactory
IGameFactory psFactory = new PlaystationFactory();
IGame ps = psFactory.CreatePlatform();
ps.PlatformSpecific();

// PcFactory
IGameFactory pcFactory = new PcFactory();
IGame pc = pcFactory.CreatePlatform();
pc.PlatformSpecific();


// AtariFactory
IGameFactory atariFactory = new AtariFactory();
IGame atari = atariFactory.CreatePlatform();
atari.PlatformSpecific();

Console.ReadLine();

interface IGame
{
    void PlatformSpecific();
}

class Atari : IGame
{
    public void PlatformSpecific()
    {
        Console.WriteLine("Bu oyun Atari platformunda geçerli bir oyundur.");
    }
}

class Pc : IGame
{
    public void PlatformSpecific()
    {
        Console.WriteLine("Bu oyun Pc platformunda geçerli bir oyundur.");
    }
}


class Playstation : IGame
{
    public void PlatformSpecific()
    {
        Console.WriteLine("Bu oyun Playstation platformunda geçerli bir oyundur.");
    }
}


interface IGameFactory
{
    IGame CreatePlatform();
}

class PcFactory : IGameFactory
{
    public IGame CreatePlatform()
    {
        return new Pc();
    }
}

class PlaystationFactory : IGameFactory
{
    public IGame CreatePlatform()
    {
        return new Playstation();
    }
}

class AtariFactory : IGameFactory
{
    public IGame CreatePlatform()
    {
        return new Atari();
    }
}