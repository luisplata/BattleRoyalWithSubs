using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Refactoring
{
    public class GameRules : MonoBehaviour
    {
        [SerializeField]
        private PlayersConfiguration _playersConfiguration;
        PlayerSpawner _playerSpawner;

        [SerializeField] private List<string> nombreDeIntegrantes;
        [SerializeField] private List<GameObject> positionInMap;
        void Start()
        {
            var powerUpsFactory = new PlayersFactory(Instantiate(_playersConfiguration));
            _playerSpawner = new PlayerSpawner(powerUpsFactory);
            foreach (var integrante in nombreDeIntegrantes)
            {
                var player = _playerSpawner.SpawnPlayer("generic");
                player.Configuration(integrante);
                var index = Random.Range(0, positionInMap.Count - 1);
                player.transform.position = positionInMap[index].transform.position;
                positionInMap.RemoveAt(index);
            }
        }
    }
}