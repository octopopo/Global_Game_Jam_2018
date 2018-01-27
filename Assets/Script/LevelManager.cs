using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int[][] allAnswer;
    public int whichLevel;

    // Use this for initialization
    void Awake()
    {
        tag = "LevelManager";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckAnswer(int[] supposeAnswer)
    {
        foreach(int num in supposeAnswer)
            Debug.Log(num);
    }
}
