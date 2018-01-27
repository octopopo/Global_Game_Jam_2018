using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AnswerList{
    [SerializeField] public int[] answer;
}

public class LevelManager : MonoBehaviour {

    //public int[] allAnswer;
    public int whichLevel;
    //only by this kind of nested structure that we can see it in the inspector window
    public AnswerList[] allAnswer;
    public int[] hi;

    // Use this for initialization
    void Awake()
    {
        tag = "LevelManager";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CheckAnswer(int[] supposeAnswer)
    {
        Debug.Log("Checking Answer");
        bool isCorrect = true;
        for(int i = 0; i < allAnswer[whichLevel].answer.Length; i++)
        {
            if(supposeAnswer[i] != allAnswer[whichLevel].answer[i])
            {
                isCorrect = false;
                return false;
            }
        }

        return true;
    }
}
