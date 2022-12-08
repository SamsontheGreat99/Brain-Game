using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int healthMin = 1;
    public int healthMax = 10;
    public int healthInit;
    public float speed = 1;
    public Text scoreText;
    public Hero hero;
    public Main main;
 
    public int health;
    protected BoundsCheck bndCheck;

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>();
    }
    void Start()
    {
        health = Random.Range(healthMin,healthMax);
        healthInit = health;
        scoreText.text = health.ToString();
    }
    

    void Update()
    {
        Move();

        if (bndCheck != null && bndCheck.offDown)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        GameObject otherGo = coll.gameObject;

        if (coll.gameObject != this.gameObject)
        {
            switch (otherGo.tag)
            {
                case "S":
                    health -= 1;
                    scoreText.text = health.ToString();
                    Destroy(otherGo);
                    if (health == 0)
                    {
                        hero.shotsRemainingS += Random.Range(0, 3);
                        Destroy(this.gameObject);
                        main.levelScore.value += healthInit;
                        break;
                    }
                    if(health < 0)
                    {
                        main.levelScore.value += health;
                        Destroy(this.gameObject);
                        break;
                    }
                    break;

                case "D":
                    health -= 2;
                    scoreText.text = health.ToString();
                    Destroy(otherGo);
                    if(health == 0)
                    {
                        hero.shotsRemainingD += Random.Range(0, 3);
                        Destroy(this.gameObject);
                        main.levelScore.value += healthInit;
                        break;
                    }
                    if (health < 0)
                    {
                        main.levelScore.value += health;
                        Destroy(this.gameObject);
                        break;
                    }
                    break;

                case "F":
                    health -= 3;
                    scoreText.text = health.ToString();
                    Destroy(otherGo);
                    if(health == 0)
                    {
                        hero.shotsRemainingF += Random.Range(0, 3);
                        Destroy(this.gameObject);
                        main.levelScore.value += healthInit;
                        break;
                    }
                    if (health < 0)
                    {
                        main.levelScore.value += health;
                        Destroy(this.gameObject);
                        break;
                    }
                    break;
            }
               
            
        }
    }

    public void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    public int Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
        }
    }
    public Vector3 pos
    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }
}
