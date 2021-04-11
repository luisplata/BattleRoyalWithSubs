using UnityEngine;

public class LogicPlayer
{
    
    private readonly IPlayerLogicView _playerLogicView;
    private readonly float _timeOfShoot;
    private float _timeOfShootDeltaTime;
    public bool CanShoot { get; private set; }

    public LogicPlayer(IPlayerLogicView playerLogicView, float timeOfShoot)
    {
        _playerLogicView = playerLogicView;
        _timeOfShoot = timeOfShoot;
    }
    
    public void GettingCloserRival(Vector3 target)
    {
        _playerLogicView.ChangeDirection(target);
        if (CanShoot)
        {
            _playerLogicView.ShootingBullet(target);
            _timeOfShootDeltaTime = 0;
            CanShoot = false;
        }
    }

    public void AddDeltaTimeShooterTime(float deltatime)
    {
        _timeOfShootDeltaTime += deltatime;
        if (_timeOfShootDeltaTime >= _timeOfShoot)
        {
            CanShoot = true;
        }
    }
}