using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemySpawner : MonoBehaviour
{

    public bool infinite = false;
    public int delay = 5; // in seconds
    public int howManyAtOnce = 1;
    public int howManyAtAll = 30; // only for finite spawner 
    public GameObject enemyPrefab;
    public GameObject toFollow;

    private float time;
    private int spawned = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (infinite)
        {
            if (time > delay)
            {
                Spawn();
            }
        }
        else if (spawned < howManyAtAll)
        {
            if (time > delay)
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        time = 0f;
        if (enemyPrefab != null)
        {
            for (int i = 0; i < howManyAtOnce; i++)
            {
                var enemy = (GameObject)Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemy.GetComponent<ChasingPlayer>().player = toFollow.transform;
                spawned++;
            }
        }
    }
}
