using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class EnemySeekLogic : MonoBehaviour {
    Blackboard my_board;
	// Use this for initialization
	void Start () {
        my_board = GetComponent<Blackboard>();
	}
	
	// Update is called once per frame
	void Update () {
        my_board["target"] = GameObject.FindGameObjectWithTag("Player").transform.position;
        Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
	}
}
