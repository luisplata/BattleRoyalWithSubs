using System;
using System.Collections.Generic;
using Refactoring;
using UnityEngine;

[CreateAssetMenu(menuName = "Bellseboss/PlayerConfiguration")]
public class PlayersConfiguration : ScriptableObject
{
    [SerializeField] private Player[] players;
    private Dictionary<string, Player> _idToPlayer;

    private void Awake()
    {
        _idToPlayer = new Dictionary<string,Player>(players.Length);
        foreach (var player in players)
        {
            _idToPlayer.Add(player.Id, player);
        }
    }

    public Player GetPlayerPrefabById(string id)
    {
        if (!_idToPlayer.TryGetValue(id, out var player))
        {
            throw new Exception($"Player with id {id} does not exit");
        }
        return player;
    }
}