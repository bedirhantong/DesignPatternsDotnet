

Uefa istanbulTournament = new IstanbulTournament();
ITournament tournament = istanbulTournament.StartATournament("WorldCup");
ITournament tournament3 = istanbulTournament.StartATournament("ChampionsLeague");

Uefa zurihTournament = new ZurihTournament();
//ITournament tournament1 = zurihTournament.StartATournament("WorldCup");
ITournament tournament4 = zurihTournament.StartATournament("ChampionsLeague");

Console.ReadLine();

interface ITournament
{
    void Start();
    void PlayTournamentMusic();
    void Finish();
}

class WorldCup : ITournament
{
    public void Finish()
    {
        Console.WriteLine("WorldCup is finished");
    }

    public void PlayTournamentMusic()
    {
        Console.WriteLine("WorldCup's tournament music is playing.");
    }

    public void Start()
    {
        Console.WriteLine("WorldCup is started");
    }
}

class ChampionsLeague : ITournament
{
    public void Finish()
    {
        Console.WriteLine("ChampionsLeague is finished");
    }

    public void PlayTournamentMusic()
    {
        Console.WriteLine("ChampionsLeague's tournament music is playing.");
    }

    public void Start()
    {
        Console.WriteLine("ChampionsLeague is started");
    }
}

abstract class Uefa
{
    protected abstract ITournament CreateATournament(string type);

    public ITournament StartATournament(string type) {
        ITournament tournament = CreateATournament(type);
        tournament.Start();
        tournament.PlayTournamentMusic();
        tournament.Finish();

        return tournament;
    }
}

class IstanbulTournament : Uefa
{
    protected override ITournament CreateATournament(string type)
    {
        return type switch
        {
            "WorldCup" => new WorldCup(),
            "ChampionsLeague" => new ChampionsLeague(),
             _ => throw new Exception($"There is no {nameof(type)} tournament."),
        };
    }
}


class ZurihTournament : Uefa
{
    protected override ITournament CreateATournament(string type)
    {
        return type switch
        {
            "ChampionsLeague" => new ChampionsLeague(),
            _ => throw new ArgumentException($"There is no {nameof(type)} tournament."),
        };
    }
}