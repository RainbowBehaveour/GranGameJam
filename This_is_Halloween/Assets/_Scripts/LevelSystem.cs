﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour {

    public int max_experience;
    public int current_experience;
    public int current_level = 1;
    public int score = 0;

    public Slider levelSlider;
    public Text currentLevel;
    public Text levelBackground;
    public Text score_text;

    PlayerAttack playerAttack;
    PlayerHealth playerHealth;
    PlayerController playerController;

    public GameObject button_dash;
    public GameObject button_damage;

    public AudioClip fx_lvl_up;
    public AudioSource fx_ui;


    // Use this for initialization
    void Start () {        
        current_experience = 0;
        levelSlider.maxValue = max_experience;
        currentLevel.text = current_level.ToString();
        levelBackground.text = current_level.ToString();
        score_text.text = "Score: " + score.ToString();

        playerAttack = GetComponent<PlayerAttack>();
        playerHealth = GetComponent<PlayerHealth>();
        playerController = GetComponent<PlayerController>();

        fx_ui = gameObject.transform.GetChild(2).GetComponent<AudioSource>();
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

        fx_ui.Play();
    }

    public void GetExperience(int experience)
    {
        current_experience += experience;

        levelSlider.value = current_experience;
    }
}
