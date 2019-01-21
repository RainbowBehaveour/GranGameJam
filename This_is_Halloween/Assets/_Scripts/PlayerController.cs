using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1.0f;
    public GameObject bullet;

	// Use this for initialization
	void Start ()
    {
        bullet = null;
	}
	
	// Update is called once per frame
	void Update () {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = Vector3.zero;
        movement.Set(moveHorizontal, moveVertical, 0f);

        transform.position += movement*speed;
	}
}
