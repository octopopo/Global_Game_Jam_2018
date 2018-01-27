using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehave : MonoBehaviour {

    public GameObject m_Wave;
	// Use this for initialization
	void Start () {
        tag = "Player";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //add a function for player to send signal
    public void SendSignal()
    {
        Debug.Log("Send Signal");
    }
}
