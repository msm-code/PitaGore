using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public abstract class Effect : MonoBehaviour
{
    private float effectTime;
    private FirstPersonControllerWithDoubleJump controller;
    public abstract void StartEffect();
    public abstract void EndEffect();
    public abstract void SetController(FirstPersonControllerWithDoubleJump controller);
    public abstract float GetEffectTime();
    public abstract FirstPersonControllerWithDoubleJump GetController();
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
