using UnityEngine;
using System.Collections;

public class FirstAidKit : PowerUp {

    protected override void givePower()
    {
        var obj = gameObject.tag == "Player";
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
