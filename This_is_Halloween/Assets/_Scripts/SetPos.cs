﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPos : MonoBehaviour {

    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Player.transform.position;
	}
}
