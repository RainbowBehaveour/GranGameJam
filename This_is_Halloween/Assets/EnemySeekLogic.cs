using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class EnemySeekLogic : MonoBehaviour {
    public int max_hp = 100;
    public int current_hp;
    public int damage = 1;
    public float radius = 30;
    public float attack_speed = 1.0f;

    Blackboard my_board;
    GameObject player;
    NavMeshAgent agent;
    float timepassed;
    
    // Use this for initialization
    void Start () {
        my_board = GetComponent<Blackboard>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        current_hp = max_hp;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 distance_from_player;
        distance_from_player = player.transform.position - transform.position;

        if (distance_from_player.magnitude <= radius)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(transform.position);;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int damage_recieved = (int)player.GetComponent<PlayerAttack>().damage;

            if (player.GetComponent<PlayerAttack>().counter == 3 && player.GetComponent<PlayerAttack>().hability_doubledamage)
                damage_recieved = (int)player.GetComponent<PlayerAttack>().damage * (int)player.GetComponent<PlayerAttack>().damage_multiplier;

            current_hp -= damage_recieved;

            if (current_hp <= 0)
            {

                player.GetComponent<LevelSystem>().GetExperience(10);

                if (player.GetComponent<LevelSystem>().current_experience >= player.GetComponent<LevelSystem>().max_experience)
                {
                    player.GetComponent<LevelSystem>().LevelUp(0.1f, 0.1f, 0.2f, 20);
                }

                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
            
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hola");
            PlayerHealth player_stats = collision.gameObject.GetComponent<PlayerHealth>();
           
            float currentTime = Time.fixedTime - timepassed;
            if (currentTime >= attack_speed)
            {
                timepassed = Time.fixedTime;
                player_stats.currentHealth -= damage;
            }
        }
    }
}
