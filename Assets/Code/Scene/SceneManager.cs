using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public bool EndGameExactlyWhenPassed = false;

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

    public String textToShow;

    public GameObject GuiForGoal;

    private bool _winned = false;
    private float _winned_timer = 0f;
    private bool _player_dead = false;

    void Start()
    {
        String toShow = GenerateStringToShow();

        var goal = (GameObject) Instantiate(GuiForGoal);
//        Gui.GetComponent<Text>().text = toShow;
        goal.GetComponentInChildren<Text>().text = toShow;
//        goal.transform.parent = guiCanvas.transform;
        Destroy(goal, 3.0f);

//        var goal = new GameObject("goal");
//        goal.AddComponent<Text>().text = toShow;
//        goal.transform.SetParent(GuiCanvas.transform);
//        Destroy(goal, 3.0f);

    }

    // Update is called once per frame
    void Update ()
    {
        if (_player_dead)
        {
            _winned_timer += Time.deltaTime;
            if (_winned_timer > 4f)
            {
                // zakonczenie gry 
                print("dead. load mainmenu scene");
                Application.LoadLevel("mainmenu");
            }
        }
        if (EndGameExactlyWhenPassed && isPassed())
        {
            if (!_winned)
            {
                _winned = true;
                var won = (GameObject)Instantiate(GuiForGoal);
                won.GetComponentInChildren<Text>().fontSize = 70;
                won.GetComponentInChildren<Text>().text = "You won!!!";
            }
        }
        if (_winned)
        {
            _winned_timer += Time.deltaTime;
            if (_winned_timer > 4f)
            {
//               zakonczenie gry 
                print("load new scene");
                Application.LoadLevel("mainmenu");
            }
        }
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

    private String GenerateStringToShow()
    {
        String toShow = (textToShow != null && textToShow.Length != 0) ? (textToShow + "\n\n") : "";
        if (timeConditionActive) toShow += ("You must survive " + timeToPass.ToString() + " seconds.\n");
        if (killedEnemyConditionActive)
            toShow += ("You must kill at least " + enemiesToKill.ToString() + " enemies.\n");
        if (placeConditionActive) toShow += "You must reach specyfic place on the map.\n";
        if (otherConditionAcvite) toShow += "You must complete specyfic goal for this map.";

        print(toShow);
        return toShow;
    }

    public void playerDead()
    {
        Texture2D overlayTexture = new Texture2D(1,1);
        Rect position = new Rect(
            x: 0,
            y: 0,
            width: Screen.width,
            height: Screen.height); 

       _player_dead = true;
        var won = (GameObject)Instantiate(GuiForGoal);
        won.GetComponentInChildren<Text>().fontSize = 80;
        won.GetComponentInChildren<Text>().text = "You're ded!!! LOOSER";
        Utils.WithGuiColor(Color.red, () => GUI.DrawTexture(position, overlayTexture));
    }
}
