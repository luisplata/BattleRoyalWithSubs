using System;
using UnityEngine;

public class EnginMovment
{
    private readonly IPlayerMovment _playerMovment;
    private float _changedDirectionDeltaTime;
    private float _changedDirectionTime;

    public Vector3 CalculateDirection()
    {
        return new Vector3(_playerMovment.GetRandomAxis(-1000, 1000), _playerMovment.GetRandomAxis(-1000, 1000),
            _playerMovment.GetRandomAxis(-1000, 1000));
    }
    
    public EnginMovment(float timeForChangeDirection, IPlayerMovment playerMovment)
    {
        _playerMovment = playerMovment;
        _changedDirectionTime = timeForChangeDirection;
    }
    
    public void EvaluateChangeDirection(float deltaTime)
    {
        if (_changedDirectionDeltaTime >= _changedDirectionTime)
        {
            _playerMovment.ChangeDirection(CalculateDirection());
            _changedDirectionDeltaTime = 0;
            _changedDirectionTime = _playerMovment.GetRandomTimeForChangeDirection();
        }
        _changedDirectionDeltaTime += deltaTime;
    }
}