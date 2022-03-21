using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float fireRate = 1f;
    [SerializeField]
    GameObject proj;
	//https://www.youtube.com/watch?v=kOzhE3_P2Mk

    float nextFire;
    void Start()
    {

        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time> nextFire){
            Instantiate(proj, transform.position, Quaternion.identity);
            nextFire=Time.time+fireRate;
        }
    }
}
