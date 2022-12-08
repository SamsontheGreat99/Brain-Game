using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public Text levelNum;

    private int level;
    private Main main;
    // Start is called before the first frame update
    void Awake()
    {
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>();
    }
    void Start()
    {
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (main.levelScore.value < 20)
        {
            level1();
        }
        if(main.levelScore.value >= 20 && main.levelScore.value < 40)
        {
            level2();
        }
        if(main.levelScore.value >= 40 && main.levelScore.value < 60)
        {
            level3();
        }
    }


    public void level1()
    {
        level = 1;
        levelNum.text = "Level: " + level.ToString();
        main.enemySpawnPerSecond = .25f;
    }

    public void level2()
    {
        level = 2;
        levelNum.text = "Level: " + level.ToString();
        main.enemySpawnPerSecond = .30f;
    }

    public void level3()
    {
        level = 3;
        levelNum.text = "Level: " + level.ToString();
        main.enemySpawnPerSecond = .5f;
    }
}
