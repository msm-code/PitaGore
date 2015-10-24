using UnityEngine;
using System.Collections;

public class PowerUpRotator : Rotator {

    public override void Collision(Collider collider)
    {
        print("jestem powerupem");
    }
}
