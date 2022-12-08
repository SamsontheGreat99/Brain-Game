using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static Main S;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;
    public GameObject[] activeEnemies;
    private Enemy enemy;
    public int cannonHealth = 100;
    public GameObject cannon;
    public float enemySpawnPerSecond = 1f;
    public float enemyDefaultPadding = 1.5f;
    public Slider levelScore;
    public Text score;

    private BoundsCheck bndCheck;
    private int maxHealth;

    private void Awake()
    {
        S = this;
        bndCheck = GetComponent<BoundsCheck>();

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
    void Start()
    {
        maxHealth = cannonHealth;
        levelScore.value = 0;
        levelScore.maxValue = cannonHealth;

    }

    // Update is called once per frame
    void Update()
    {
        activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        score.text = "Score: " + levelScore.value.ToString();
        
        for(int i = 0; i < activeEnemies.Length; i++)
        {
            enemy = activeEnemies[i].GetComponent<Enemy>();
            BoundsCheck go = activeEnemies[i].GetComponent<BoundsCheck>();
            if (go.offDown)
            {
                //cannonHealth -= enemy.Health;
                levelScore.value -= enemy.Health;
                if (cannonHealth <= 0)
                {
                    Destroy(cannon);
                }
            }
        }
        
    }

    public void SpawnEnemy()
    {
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        float enemyPadding = enemyDefaultPadding;

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;


        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
}
