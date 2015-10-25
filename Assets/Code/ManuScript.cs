using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManuScript : MonoBehaviour {
    public Button Adventure;
    public Button Arena;
    public Button Quit;

    // Use this for initialization
    void Start () {
        Adventure = Adventure.GetComponent<Button>();
        Arena = Arena.GetComponent<Button>();
        Quit = Quit.GetComponent<Button>();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayAdventure()
    {

    }

    public void PlayArena()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
