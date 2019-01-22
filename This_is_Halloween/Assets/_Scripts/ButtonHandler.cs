using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void UpdateDamageMultiplier()
    {
        player.GetComponent<PlayerAttack>().damage_multiplier += 0.1f;
        Debug.Log(player.GetComponent<PlayerAttack>().damage_multiplier);
    }

    public void UpdateDashVelocity()
    {
        player.GetComponent<PlayerController>().dash_speed += 0.2f;
        Debug.Log(player.GetComponent<PlayerController>().dash_speed);
    }
}
