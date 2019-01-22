using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour {

    // Use this for initialization
    Vector3 startPos = Vector3.zero;
    public float MaxDistance=8;
    public float lives_Time = 5;
    float startTime;
    float currentTime;
    void Start () {
        startPos = transform.position;
        startTime = Time.fixedTime;
    }

    private void Update()
    {
        float actualDistance = Vector3.Distance(startPos, transform.position);
        currentTime = Time.fixedTime - startTime;
       if(actualDistance >= MaxDistance || currentTime>= lives_Time)
        {
            Destroy(transform.gameObject);
        }
    }
}
