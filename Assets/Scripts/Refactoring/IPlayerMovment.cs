using UnityEngine;

public interface IPlayerMovment
{
    float GetRandomAxis(float min, float max);
    void ChangeDirection(Vector3 calculateDirection);
    float GetRandomTimeForChangeDirection();
}