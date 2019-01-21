﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour {

    public int max_experience;
    public int current_experience;
    public int current_level;

    public Slider levelSlider;

    PlayerAttack playerAttack;
    PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        current_level = 1;
        current_experience = 0;
        levelSlider.maxValue = max_experience;

        playerAttack = GetComponent<PlayerAttack>();
        playerHealth = GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {

        
	}

    public void LevelUp(float bullet_speed, float fire_rate, float damage, int max_health)
    {
        playerAttack.bullet_speed += bullet_speed;
        playerAttack.fireRate += fire_rate;
        playerAttack.damage += damage;
        playerHealth.maxHealth += max_health;

        current_level++;

        current_experience = 0;

        max_experience = (int)(max_experience*1.5f);

        levelSlider.maxValue = max_experience;
    }

    public void GetExperience(int experience)
    {
        current_experience += experience;

        levelSlider.value = current_experience;
    }
}
