﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel("Main Menu");
        }
    }
}
