using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float dash_speed = 0.0005f;
    float dash_time = 0.3f;
    bool isDash = false;
    float lastSpaceDown;
    
    float currentCooldown;

    public float speed = 1.0f;
    public float rotation_speed = 0.05f;
    public float dashCooldown = 0.5f;
    public GameObject playerSprite;


    private Camera cam;

    Vector3 direction = Vector3.zero;
    Vector3 player_screenPos = Vector3.zero;
    Animator anim;

    public uint numEnemiesKilled = 0;
    public uint maxEnemies=20;
    public GameObject youWinText;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        anim = playerSprite.GetComponent<Animator>();
        currentCooldown = 3.0f;
        youWinText.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        //Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;
        movement.Set(moveHorizontal, 0f, moveVertical);

        CalculateDirection();
        float rot_angle = (Mathf.Acos(direction.z) * 180) / Mathf.PI;

        if (Input.mousePosition.x < player_screenPos.x)
        {
            rot_angle = -rot_angle;
        }

        anim.SetFloat("Angle", rot_angle);
        transform.position += movement * speed;//transform.up * moveVertical * speed;

        Quaternion mouse_quaternion = Quaternion.Euler(90, rot_angle, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, mouse_quaternion, rotation_speed);
        currentCooldown = Time.fixedTime - lastSpaceDown;
        
        if (Input.GetKeyDown(KeyCode.Space) && !isDash && currentCooldown >= dashCooldown)
        {
            isDash = true;
            lastSpaceDown = Time.fixedTime;
            currentCooldown = dashCooldown;
        }

        if (isDash)
        {
            float currentTime = Time.fixedTime - lastSpaceDown;
            if (currentTime >= dash_time)
            {
                isDash = false;
            }
            transform.position += movement * dash_speed;
        }
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

