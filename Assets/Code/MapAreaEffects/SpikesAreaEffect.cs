using UnityEngine;
using System.Collections;

public class SpikesAreaEffect : MapAreaEffect
{

    public GameObject spikesPrefab;

    protected override void ReactOnPlayer(GameObject gameObject)
    {
        var spikes = (GameObject) Instantiate(spikesPrefab, transform.position, Quaternion.identity);
        spikes.GetComponent<GrowSpikes>().GrowAndAttack();
    }

    protected override void ReactOnEnemy(GameObject gameObject){}

}
