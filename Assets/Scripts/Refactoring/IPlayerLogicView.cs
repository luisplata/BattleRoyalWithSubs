using UnityEngine;

public interface IPlayerLogicView
{
    void ChangeDirection();
    void ChangeDirection(Vector3 target);
    float GetRandomTimeForChangeDirection();
    void ShootingBullet(Vector3 target);
}