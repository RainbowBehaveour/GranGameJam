using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class EnemySeekLogic : MonoBehaviour {
    public int max_hp = 100;
    public int current_hp;
    public int damage = 1;
    public float radius = 30;
    public float attack_speed = 1.0f;
    public float attack_range = 0.5f;
    public int experience = 10;

    Blackboard my_board;
    GameObject player;
    NavMeshAgent agent;
    float timepassed;
    bool isAttacking = false;
    
   
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
            if (distance_from_player.magnitude <= attack_range)
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }

            if (isAttacking)
            {
                PlayerHealth player_stats = player.GetComponent<PlayerHealth>();

                float currentTime = Time.fixedTime - timepassed;
                if (currentTime >= attack_speed)
                {
                    timepassed = Time.fixedTime;
                    player_stats.TakeDamage(damage);
                }
            }
        }
        else
        {
            agent.SetDestination(transform.position);
 
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

                player.GetComponent<LevelSystem>().GetExperience(experience);
                player.GetComponent<LevelSystem>().score += experience;
                player.GetComponent<LevelSystem>().score_text.text = "Score: " + player.GetComponent<LevelSystem>().score;

                if (player.GetComponent<LevelSystem>().current_experience >= player.GetComponent<LevelSystem>().max_experience)
                {
                    player.GetComponent<LevelSystem>().LevelUp(0.5f, 0.5f, 0.015f, 0.03f, 5, 20);
                }

                Destroy(gameObject);
                player.GetComponent<PlayerController>().numEnemiesKilled += 1;
                if(player.GetComponent<PlayerController>().numEnemiesKilled >= player.GetComponent<PlayerController>().maxEnemies)
                {
                    player.GetComponent<PlayerController>().youWinText.SetActive(true);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }


            }

            Destroy(collision.gameObject);
            
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
