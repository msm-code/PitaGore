using UnityEngine;
using System.Collections;

public class PowerUpRotator : Rotator {

    public override void Collision(Collider collider)
    {
        var newPowerUp = gameObject.GetComponent<PowerUp>();
        var player = collider.gameObject;
        newPowerUp.GivePower(player);
    }
}
