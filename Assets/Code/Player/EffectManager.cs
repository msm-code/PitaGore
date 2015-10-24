using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class EffectManager : MonoBehaviour {
    private bool timerStarted = false;
    private float timer = 0f;
    private float maxTime = 1f;
    List<Effect> effectsList = new List<Effect>();
    private Effect currentEffect;

    // Use this for initialization
    void Start () {
	    
	}

    public void StartEffect(Effect effect)
    {
        this.timer = 0f;
        StartTime(effect.GetEffectTime(), effect);
    }

    public void StopEffect(Effect effect)
    {
        effect.EndEffect();
        currentEffect = null;
        
    }

    public void AddEffect(Effect effect)
    {
        this.effectsList.Add(effect);
        this.currentEffect = effect;
        StartEffect(effect);
    }

    public void StartTime(float maxTime, Effect effect)
    {
        this.timerStarted = true;
        this.maxTime = maxTime;
        var controller = gameObject.GetComponent<FirstPersonControllerWithDoubleJump>();
        effect.SetController(controller);
        effect.StartEffect();
    }

    // Update is called once per frame
    void Update () {
        if (this.timerStarted)
        {
            this.timer += Time.deltaTime;

            if (this.timer >= maxTime)
            {
                StopEffect(this.currentEffect);
                effectsList.Remove(this.currentEffect);
                timerStarted = false;
            }
        }
    }
}
