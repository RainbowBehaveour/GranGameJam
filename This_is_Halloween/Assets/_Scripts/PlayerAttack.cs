using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public GameObject bullet;

    public Text attack;
    public Text health;
    public Text fire_rate;
    public Text speed;
    public Text bullet_speed_text;
    public Text rotation_speed;

    public float bullet_speed = 1.0f;
    public float damage = 1.0f;
    public float fireRate = 0.5f;

    bool MouseRepeat = false;
    bool canShoot = true;
    float lastTimeCreatedBullet;

    public bool hability_doubledamage;
    public  int counter = 0;
    public float damage_multiplier = 1.0f;

    public AudioClip fx_throw;
    public AudioSource fx_player;

    // Use this for initialization
    void Start () {
        fx_player = gameObject.GetComponentInChildren<AudioSource>();
        UpdatePanel();

        fx_player.Play();
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
        fx_player.Play();
    }

    public void UpdatePanel()
    {
        attack.text = "Damage: " + damage;
        health.text = "Health: " + gameObject.GetComponent<PlayerHealth>().maxHealth;
        fire_rate.text = "Fire rate: " + fireRate;
        speed.text = "Speed: " + gameObject.GetComponent<PlayerController>().speed;
        bullet_speed_text.text = "Bullet Speed: " + bullet_speed;
        rotation_speed.text = "Rotation Speed: " + gameObject.GetComponent<PlayerController>().rotation_speed;

    }

}
