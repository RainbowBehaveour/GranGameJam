using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = Color.red;

    bool damaged = false;
    bool isDead = false;

	// Use this for initialization
	void Start () {

        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
    }
	
	// Update is called once per frame
	void Update () {
		if(damaged)
        {
            damageImage.color = flashColour;
            damaged = false;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

	}

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if(currentHealth<=0 && !isDead)
        {
            Dead();
        }
    }

    void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
