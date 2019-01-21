using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1.0f;
    public float bullet_speed = 1.0f;
    public float max_health = 100.0f;
    public float current_health = 100.0f;
    public float damage = 1.0f;
    public float fireRate = 0.5f;
    public float rotation_speed = 0.05f;

    public GameObject bullet;
    private Camera cam;
    Vector3 direction = Vector3.zero;
    Vector3 player_screenPos = Vector3.zero;

    bool MouseRepeat = false;
    bool canShoot = true;
    float lastTimeCreatedBullet;
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
        Quaternion mouse_quaternion = Quaternion.Euler(90, rot_angle, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, mouse_quaternion, rotation_speed);

       

        //Create Shoot
        if ((Input.GetMouseButtonDown(0) || MouseRepeat) && canShoot)
        {
            CreateBullet(mouse_quaternion);
            canShoot = false;
            lastTimeCreatedBullet = Time.fixedTime;
        }

        if(!canShoot)
        {
            float currentTime = Time.fixedTime - lastTimeCreatedBullet;
            if(currentTime>=fireRate)
            {
                canShoot = true;
            }
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            MouseRepeat = false;
        }

	}

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) && MouseRepeat == false)
            {
              MouseRepeat = true;
            }


    }
    void CreateBullet(Quaternion rotation)
    {
        Vector3 spawn_pos = transform.position + transform.up;
        GameObject new_bullet = Instantiate(bullet, spawn_pos, transform.rotation);
        Rigidbody rb = new_bullet.GetComponent<Rigidbody>();

        rb.velocity = transform.up * bullet_speed;
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
