using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class SpeedUp : Effect {

    private float effectTime = 5;
    private FirstPersonControllerWithDoubleJump controller;
    // Use this for initialization

    public override FirstPersonControllerWithDoubleJump GetController()
    {
        return this.controller;
    }

    public override float GetEffectTime()
    {
        return this.effectTime;
    }

    public override void SetController(FirstPersonControllerWithDoubleJump Controller)
    {
        this.controller = Controller;
    }

    public override void StartEffect()
    {
        this.controller.AddSpeed(20);
    }

    public override void EndEffect()
    {
        this.controller.AddSpeed(-20);
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
