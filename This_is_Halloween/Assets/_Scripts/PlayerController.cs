using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1.0f;
    public float bullet_speed = 1.0f;

    public GameObject bullet;
    private Camera cam;

    // Use this for initialization
    void Start ()
    {
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {

        //Movement
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = Vector3.zero;
        movement.Set(moveHorizontal, moveVertical, 0f);

        transform.position += movement*speed;

        //Create Shoot
        if(Input.GetMouseButtonDown(0))
        {
            SetDirection();
        }
	}

    void SetDirection()
    {
        GameObject new_bullet = Instantiate(bullet, transform.position, transform.rotation);

        Vector2 mousePos = Vector2.zero;
        Vector3 point = Vector3.zero;
        Vector3 direction = Vector3.zero;

        mousePos.Set(Input.mousePosition.x, Input.mousePosition.y);
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z));
        direction.x = point.x - transform.position.x;
        direction.y = point.y - transform.position.y;
        direction.z = 0;

        direction.Normalize();


        Rigidbody2D rb = new_bullet.GetComponent<Rigidbody2D>();

        rb.velocity = direction * bullet_speed;
    }

   
}
