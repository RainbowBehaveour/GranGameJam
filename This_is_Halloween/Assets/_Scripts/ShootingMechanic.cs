using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour {

    // Use this for initialization
    Vector3 startPos = Vector3.zero;
    public float MaxDistance=5;
    void Start () {
        startPos = transform.position; 

    }

    private void Update()
    {
        float actualDistance = Vector3.Distance(startPos, transform.position);
       if(actualDistance >= MaxDistance)
        {
            Destroy(transform.gameObject);
        }
    }
}
