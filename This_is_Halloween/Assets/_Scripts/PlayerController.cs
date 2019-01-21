using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1.0f;
    public float bullet_speed = 1.0f;
    public float max_health = 100.0f;
    public float current_health = 100.0f;
    public float damage = 1.0f;

    public GameObject bullet;
    private Camera cam;
    Vector3 direction = Vector3.zero;
    Vector3 player_screenPos = Vector3.zero;

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
        movement.Set(moveHorizontal, 0f, moveVertical);

        CalculateDirection();
        float rot_angle = (Mathf.Acos(direction.z) * 180) / Mathf.PI;

        if(Input.mousePosition.x < player_screenPos.x)
        {
            rot_angle = -rot_angle;
        }

        transform.position += movement*speed;
        transform.rotation = Quaternion.Euler(90, rot_angle, 0);

       

        //Create Shoot
        if (Input.GetMouseButtonDown(0))
        {
            CreateBullet();
        }

	}

    void CreateBullet()
    {
        GameObject new_bullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody rb = new_bullet.GetComponent<Rigidbody>();

        rb.velocity = direction * bullet_speed;
    }

    //Calculate Direction between Mouse & Player owo
   void CalculateDirection()
    {
        Vector2 mousePos = Vector2.zero;

        mousePos.Set(Input.mousePosition.x, Input.mousePosition.y);
        player_screenPos = cam.WorldToScreenPoint(transform.position);

        direction.x = Input.mousePosition.x - player_screenPos.x;
        direction.y = 0f;
        direction.z = Input.mousePosition.y - player_screenPos.y;
        direction.Normalize();
    }

}
