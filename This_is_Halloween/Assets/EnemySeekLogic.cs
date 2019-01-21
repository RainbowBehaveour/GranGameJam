using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class EnemySeekLogic : MonoBehaviour {
    Blackboard my_board;
    GameObject player;
    int hp = 100;
    int damage = 1;
	// Use this for initialization
	void Start () {
        my_board = GetComponent<Blackboard>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 distance_from_player;
        distance_from_player = player.transform.position - transform.position;
        if (distance_from_player.magnitude <= GetComponent<SphereCollider>().radius)
        {
            my_board["target"] = GameObject.FindGameObjectWithTag("Player").transform.position;
            Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        else
        {
            my_board["target"] = transform.position;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 10;
        }
    }
}
