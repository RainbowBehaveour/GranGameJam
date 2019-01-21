using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject bullet;

    public float bullet_speed = 1.0f;
    public float damage = 1.0f;
    public float fireRate = 0.5f;

    bool MouseRepeat = false;
    bool canShoot = true;
    float lastTimeCreatedBullet;

    public bool hability_doubledamage;
    public  int counter = 0;
    public float damage_multiplier = 1.0f;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Create Shoot
        if ((Input.GetMouseButtonDown(0) || MouseRepeat) && canShoot)
        {
           CreateBullet(bullet_speed);
           counter++;
           canShoot = false;
           lastTimeCreatedBullet = Time.fixedTime;
        }

        if (!canShoot)
        {
            float currentTime = Time.fixedTime - lastTimeCreatedBullet;
            if (currentTime >= fireRate)
            {
                canShoot = true;
            }

        }
        if (Input.GetMouseButtonUp(0))
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

    public void CreateBullet(float bullet_speed)
    {
        Vector3 spawn_pos = transform.position + transform.up;
        GameObject new_bullet = Instantiate(bullet, spawn_pos, transform.rotation);
        Rigidbody rb = new_bullet.GetComponent<Rigidbody>();

        rb.velocity = transform.up * bullet_speed;
    }

}
