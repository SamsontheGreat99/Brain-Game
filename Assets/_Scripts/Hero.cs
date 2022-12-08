using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public static Hero S;

    [Header("Set in Inspector")]
    public float rangeLeft = -45;
    public float rangeRight = 45;
    public float sensitivityZ = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed;
    public int shotsRemainingS = 10;
    public int shotsRemainingD = 10;
    public int shotsRemainingF = 10;

    private Vector3 mousePosition;
    private Vector3 direction;

    private GameObject mp;
    private GameObject ap;
    private Text proj1RemainingText;
    private Text proj2RemainingText;
    private Text proj3RemainingText;


    private void Awake()
    {
        mp = GameObject.Find("MovingPart");
        ap = GameObject.Find("AimingPoint");
        proj1RemainingText = GameObject.Find("Proj1RemainingText").GetComponent<Text>();
        proj2RemainingText = GameObject.Find("Proj2RemainingText").GetComponent<Text>();
        proj3RemainingText = GameObject.Find("Proj3RemainingText").GetComponent<Text>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        proj1RemainingText.text = shotsRemainingS.ToString();
        proj2RemainingText.text = shotsRemainingD.ToString();
        proj3RemainingText.text = shotsRemainingF.ToString();


        LockedRotation();
        
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(shotsRemainingS > 0)
            {
                FireS();
                shotsRemainingS--;
            }
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (shotsRemainingD > 0)
            {
                FireD();
                shotsRemainingD--;
            }
        }

        else if (Input.GetKeyDown(KeyCode.F))
        {
            if (shotsRemainingF > 0)
            {
                FireF();
                shotsRemainingF--;
            }
        }
    }

    void LockedRotation()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
            Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));

        GetComponentInChildren<Rigidbody>().transform.eulerAngles = 
            new Vector3(0, 0,Mathf.Atan2((mousePosition.y - transform.position.y), 
            (mousePosition.x - transform.position.x)) *Mathf.Rad2Deg - 90);
    }

    void FireS()
    {
        GameObject projGo = Instantiate<GameObject>(projectilePrefab);
        projGo.tag = "S";
        projGo.transform.position = transform.position;
        Rigidbody rb = projGo.GetComponent<Rigidbody>();
        //Vector3 projRot = mp.transform.localEulerAngles;

        Vector3 aim = ap.transform.position - projGo.transform.position;

        rb.velocity = aim * projectileSpeed;
    }

    void FireD()
    {
        GameObject projGo = Instantiate<GameObject>(projectilePrefab);
        projGo.tag = "D";
        projGo.transform.position = transform.position;
        Rigidbody rb = projGo.GetComponent<Rigidbody>();
        //Vector3 projRot = mp.transform.localEulerAngles;

        Vector3 aim = ap.transform.position - projGo.transform.position;

        rb.velocity = aim * projectileSpeed;
    }

    void FireF()
    {
        GameObject projGo = Instantiate<GameObject>(projectilePrefab);
        projGo.tag = "F";
        projGo.transform.position = transform.position;
        Rigidbody rb = projGo.GetComponent<Rigidbody>();
        //Vector3 projRot = mp.transform.localEulerAngles;

        Vector3 aim = ap.transform.position - projGo.transform.position;

        rb.velocity = aim * projectileSpeed;
    }
}
