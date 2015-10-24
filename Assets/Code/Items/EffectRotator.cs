using UnityEngine;
using System.Collections;

public class EffectRotator : Rotator {

    public override void Collision(Collider collider)
    {
        var newEffect = gameObject.GetComponent<Effect>();
        var player = collider.gameObject;
        var manager = player.GetComponent<EffectManager>();
        manager.AddEffect(newEffect);
    }
}
