using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using System;

public class MapAreaEffect : MonoBehaviour
{

    public bool triggerReactOnPlayer;
    public bool triggerReactOnEnemy;

    private bool isPlayerColliding = false;
    private bool isEnemyColliding = false;

    void OnTriggerEnter(Collider collider)
    {
        //TODO: jakby sie kontroler zmienil to trzeba zmienic
        if (collider.gameObject.GetComponent<FirstPersonController>() != null)
        {
            if (!isPlayerColliding)
            {
                isPlayerColliding = true;
                if (triggerReactOnPlayer) ReactOnPlayer(collider.gameObject);
            }
        }
        else
        {
            if (!isEnemyColliding)
            {
                isEnemyColliding = true;
                if (triggerReactOnEnemy) ReactOnEnemy(collider.gameObject);
            }
           
        }
    }

    void OnTriggerExit(Collider collider)
    {
        //TODO: to tez, jw.
        if (collider.gameObject.GetComponent<FirstPersonController>() != null)
        {
            if (isPlayerColliding) isPlayerColliding = false;
        }
        else
        {
            if (isEnemyColliding) isEnemyColliding = false;
        }
    }

    protected virtual void ReactOnPlayer(GameObject gameObject)
    {
        print("reaction on player");
    }

    protected virtual void ReactOnEnemy(GameObject gameObject)
    {
        print("reaction on enemy");
    }

}
