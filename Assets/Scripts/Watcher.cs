﻿using UnityEngine;
using System.Collections;

public class Watcher : MonoBehaviour {

    public GameObject focus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(focus.transform.position);
	}
}
