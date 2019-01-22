using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour {

    public int max_experience;
    public int current_experience;
    public int current_level = 1;

    public Slider levelSlider;
    public Text currentLevel;
    public Text levelBackground;

    PlayerAttack playerAttack;
    PlayerHealth playerHealth;
    PlayerController playerController;

    public GameObject button_dash;
    public GameObject button_damage;


    // Use this for initialization
    void Start () {        
        current_experience = 0;
        levelSlider.maxValue = max_experience;
        currentLevel.text = current_level.ToString();
        levelBackground.text = current_level.ToString();

        playerAttack = GetComponent<PlayerAttack>();
        playerHealth = GetComponent<PlayerHealth>();
        playerController = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            GetExperience(10);
            if(current_experience >= max_experience)
            {
                LevelUp(0.1f, 0.1f, 0.01f, 0.05f, 0.2f, 20);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {            
            playerHealth.TakeDamage(10);            
        }

    }

    public void LevelUp(float bullet_speed, float rotation_speed, float player_speed, float fire_rate, float damage, int max_health)
    {
        playerAttack.bullet_speed += bullet_speed;
        playerAttack.fireRate -= fire_rate;
        playerAttack.damage += damage;
        playerHealth.maxHealth += max_health;
        playerHealth.currentHealth = playerHealth.maxHealth;
        playerController.speed += player_speed;
        playerController.rotation_speed += rotation_speed;

        current_level++;

        current_experience = 0;

        max_experience = (int)(max_experience*1.5f);

        levelSlider.maxValue = max_experience;
        levelSlider.value = current_experience;
        currentLevel.text = current_level.ToString();
        levelBackground.text = current_level.ToString();

        playerAttack.UpdatePanel();

        playerHealth.healthSlider.maxValue = playerHealth.maxHealth;
        playerHealth.healthSlider.value = playerHealth.currentHealth;

        button_damage.SetActive(true);
        button_dash.SetActive(true);

    }

    public void GetExperience(int experience)
    {
        current_experience += experience;

        levelSlider.value = current_experience;
    }
}
