using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceManager : MonoBehaviour {
    public GameObject m_Player;
    public GameObject[] m_Star;
    public GameObject[] numberSprite;
    public GameObject m_LevelManager;
    //this array was for storing whether the star has been pressed or not
    public int[] starIsPressed;
    public int starCount;
    //this array store the correct answer
    public int[] answerOrder;
    //this array store the answer of the player
    public int[] m_AnsOrder;
    public int sequenceCount = 0;
	// Use this for initialization
	void Start () {
        starCount = m_Star.Length;
        if (m_Player == null)
        {
            Debug.Log("You haven't assign player");
        }
        if(m_Star.Length == 0)
        {
            Debug.Log("You haven't assign any star inside");
        }
        if(numberSprite.Length == 0)
        {
            Debug.Log("You forget to attach the number sprites");
        }

        m_LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
        if(m_LevelManager == null)
        {
            Debug.Log("Where is Level Manager");
        }

        //Initialize the sequence Count and array of storing which was been pressed
        sequenceCount = 0;
        starIsPressed = new int[m_Star.Length];
        for(int i = 0; i < m_Star.Length; i++)
        {
            starIsPressed[i] = -1;
        }
        //initialize the m_AnsOrder
        m_AnsOrder = new int[m_Star.Length];

        //initially set all number sprite invisible
        foreach(GameObject m_Num in numberSprite)
        {
            m_Num.GetComponent<SpriteRenderer>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        mouseEventHanlde();
        keyboardEventHandle();
    }

    //it get the distance for all star with player
    public void getDistance()
    {
        Vector3 playerPos = m_Player.GetComponent<Transform>().position;
        Vector3 starPos;
        float starDist;
        foreach(GameObject littleStar in m_Star)
        {
            starPos = littleStar.GetComponent<Transform>().position;
            starDist = Vector3.Distance(playerPos, starPos);
            //for now I just simply divide the distance by 10, so that the distance will be in the range of 0 ~ 1
            starDist /= 10.0f;
            Debug.Log(littleStar.name + ": " + starDist);
        }
    }

    //this can be called by wave when they try to play some audio
    public float singleStarDistance(Vector3 starPos)
    {
        Vector3 playerPos = m_Player.GetComponent<Transform>().position;
        float starDist = Vector3.Distance(playerPos, starPos);
        return starDist;
    }

    public void mouseEventHanlde()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse is Down");
            //Beware of the usage of 2D component
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitInfo.collider != null)
            {
                //Debug.Log("Hit" + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Star")
                {
                    //Debug.Log("Hit" + hitInfo.transform.gameObject.name);
                    string nameString = hitInfo.transform.gameObject.name;
                    string numString = nameString.Substring(nameString.Length-1);
                    PressingStar(int.Parse(numString));
                    //Debug.Log("number extracted: " + numString);
                }
                else if (hitInfo.transform.gameObject.tag == "Player")
                {
                    hitInfo.transform.gameObject.GetComponent<PlayerBehave>().SendSignal();
                }
                else if(hitInfo.transform.gameObject.tag == "SendMessage")
                {
                    int[] myAnswer = new int[m_Star.Length];
                    for(int i = 0;i < m_Star.Length; i++)
                    {
                        for(int j = 0; j < m_Star.Length; j++)
                        {
                            if(starIsPressed[j] == i)
                            {
                                myAnswer[i] = j;
                            }
                        }
                    }
                    bool isCorrect = m_LevelManager.GetComponent<LevelManager>().CheckAnswer(myAnswer);
                    Debug.Log("The Answer is: " + isCorrect);
                    if (!isCorrect)
                    {
                        clearArray();
                        clearNumber();
                    }
                }
            }
        }
    }

    public void keyboardEventHandle()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_Star[0].GetComponent<StarBehave>().playSound();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_Star[1].GetComponent<StarBehave>().playSound();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_Star[2].GetComponent<StarBehave>().playSound();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            m_Star[3].GetComponent<StarBehave>().playSound();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            foreach(GameObject m_Num in numberSprite)
            {
                m_Num.GetComponent<SpriteRenderer>().enabled = !m_Num.GetComponent<SpriteRenderer>().enabled;
            }
        }
    }

    public void PressingStar(int targetStar)
    {
        Debug.Log("number passing in is: " + targetStar);
        // starIsPressed[i] = -1;
        if (starIsPressed[targetStar] == -1)
        {
            starIsPressed[targetStar] = sequenceCount;
           // m_AnsOrder[sequenceCount] = targetStar;
            sequenceCount++;
        }
        else
        {
            int tarNum = starIsPressed[targetStar];
            //starIsPressed[targetStar] = -1;
            for(int i = 0; i < starIsPressed.Length; i++)
            {
                /*if(starIsPressed[i] != -1 && starIsPressed[i] >= tarNum)
                {
                    starIsPressed[i] -= 1;
                }*/
                if (starIsPressed[i] >= tarNum)
                {
                    starIsPressed[i] = -1;
                    sequenceCount--;
                }
            }
            /*for(int i = tarNum; i < m_AnsOrder.Length-1; i++)
            {
                m_AnsOrder[i] = m_AnsOrder[i + 1];
            }*/
        }

        //Vector3 targetStarPos = m_Star[targetStar].GetComponent<Transform>().position;
        clearNumber();
        
    }

    void clearArray()
    {
        sequenceCount = 0;
        for (int i = 0; i < starIsPressed.Length; i++)
        {
            starIsPressed[i] = -1;
        }
    }

    void clearNumber()
    {
        for (int i = 0; i < numberSprite.Length; i++)
        {
            numberSprite[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int i = 0; i < starIsPressed.Length; i++)
        {
            if (starIsPressed[i] != -1)
            {
                Vector3 starPos = m_Star[i].GetComponent<Transform>().position;
                Vector3 numPos = starPos + new Vector3(1.0f, 0.0f, 0.0f);
                numberSprite[starIsPressed[i]].GetComponent<Transform>().position = numPos;
                numberSprite[starIsPressed[i]].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
