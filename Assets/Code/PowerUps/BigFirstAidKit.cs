using UnityEngine;
using System.Collections;

public class BigFirstAidKit : PowerUp {

    public override void GivePower(GameObject player)
    {
        player.GetComponent<HasHealth>().ReceiveHealing(100);

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
