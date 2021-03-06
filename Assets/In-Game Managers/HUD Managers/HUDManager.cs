﻿using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

	public static HUDManager hUDManager;

	public GameObject hUDCanvas;//begins as stock, then gets instantiated
	public GameObject healthBarCanvas;
	public GameObject healthBarContainerStock;

	void Awake () {
		if (hUDManager == null) {//like a singleton
			//DontDestroyOnLoad (gameObject);
			hUDManager = this;
		} else { //if (menuColors != null)
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		healthBarCanvas = (GameObject)Instantiate(healthBarCanvas, Vector2.zero, Quaternion.identity);
		healthBarCanvas.GetComponent<Canvas>().sortingOrder = 0;

		hUDCanvas = (GameObject) Instantiate (hUDCanvas, Vector2.zero, Quaternion.identity);
		hUDCanvas.GetComponent<Canvas>().sortingOrder = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
