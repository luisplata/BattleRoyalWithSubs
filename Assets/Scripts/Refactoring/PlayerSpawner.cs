using Refactoring;

public class PlayerSpawner
{
    private readonly PlayersFactory _playersFactory;

    public PlayerSpawner(PlayersFactory playersFactory)
    {
        _playersFactory = playersFactory;
    }
        
    // Logic

    public Player SpawnPlayer(string id)
    {
        return _playersFactory.Create(id);
    }
}