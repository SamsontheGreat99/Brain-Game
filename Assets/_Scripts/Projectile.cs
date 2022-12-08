using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck;
    // Start is called before the first frame update

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bndCheck.offUp || bndCheck.offDown || bndCheck.offLeft || bndCheck.offRight)
        {
            Destroy(this.gameObject);
        }
    }
}
