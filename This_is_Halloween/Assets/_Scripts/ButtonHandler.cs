using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

    GameObject player;
    public GameObject button_dash;
    public GameObject button_damage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void UpdateDamageMultiplier()
    {
        player.GetComponent<PlayerAttack>().damage_multiplier += 0.1f;
        Debug.Log(player.GetComponent<PlayerAttack>().damage_multiplier);
        button_damage.SetActive(false);
        button_dash.SetActive(false);
    }

    public void UpdateDashVelocity()
    {
        player.GetComponent<PlayerController>().dash_speed += 0.2f;
        Debug.Log(player.GetComponent<PlayerController>().dash_speed);
        button_dash.SetActive(false);
        button_damage.SetActive(false);
    }


}
