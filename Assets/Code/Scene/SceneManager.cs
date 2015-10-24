using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{

    public bool timeConditionActive = true;
    public bool killedEnemyConditionActive = false;
    public bool placeConditionActive = false;
    public bool otherConditionAcvite = false;

    private float time = 0f;
    public float timeToPass = 0f;
    public int enemiesToKill = 0;

    public bool oneConditionToAccept = false;

    private bool timeConditionPassed = false;
    private bool killedEnemyConditionPassed = false;
    private bool placeConditionPassed = false;
    private bool otherConditionPassed = false;

    private int killedEnemyCounter = 0;
    private bool placeVisited = false;
    private bool otherDone = false;

    // Update is called once per frame
    void Update ()
    {
        if (timeConditionActive)
        {
            time += Time.deltaTime;
            if (time > timeToPass) timeConditionPassed = true;
        }
    }

    public bool isPassed()
    {
        if (oneConditionToAccept)
            return isPassedOneCondition();
        else
            return isPassedAllConditions();
    }

    private bool isPassedOneCondition()
    {
        bool passed = false;
        if (timeConditionActive && timeConditionPassed) passed = true;
        if (killedEnemyConditionActive && killedEnemyConditionPassed) passed = true;
        if (placeConditionActive && placeConditionPassed) passed = true;
        if (otherConditionAcvite && otherConditionPassed) passed = true;
        return passed;
    }

    private bool isPassedAllConditions()
    {
        bool passed = true;
        if (timeConditionActive && !timeConditionPassed) passed = false;
        if (killedEnemyConditionActive && !killedEnemyConditionPassed) passed = false;
        if (placeConditionActive && !placeConditionPassed) passed = false;
        if (otherConditionAcvite && !otherConditionPassed) passed = false;
        return passed;
    }

    public void enemyKilled()
    {
        this.killedEnemyCounter++;
        if (killedEnemyCounter >= enemiesToKill) killedEnemyConditionPassed = true;
    }

    public void otherConditionCompleted()
    {
        this.otherConditionPassed = true;
    }

    public void playerVisitedPlace()
    {
        this.placeVisited = true;
    }
}
