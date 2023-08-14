using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{
    void CollisionEffect(Player player);    // restrict obstacles to make decelerate and stop methods
}
