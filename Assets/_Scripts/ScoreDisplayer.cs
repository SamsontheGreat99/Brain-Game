using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    public Text FinalScore;

    private Text main;
    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>().score;
    }

    // Update is called once per frame
    void Update()
    {
        FinalScore.text = main.text;
    }
}
