using UnityEngine;
using System.Collections;

public class MediumFirstAidKit : PowerUp {

    public override void GivePower(GameObject player)
    {
        player.GetComponent<HasHealth>().ReceiveHealing(50);

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
