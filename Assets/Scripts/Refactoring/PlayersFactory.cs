using Refactoring;
using UnityEngine;

public class PlayersFactory
{
    private readonly PlayersConfiguration _playersConfiguration;

    public PlayersFactory(PlayersConfiguration playersConfiguration)
    {
        this._playersConfiguration = playersConfiguration;
    }
        
    public Player Create(string id)
    {
        var prefab = _playersConfiguration.GetPlayerPrefabById(id);

        return Object.Instantiate(prefab);
    }
}