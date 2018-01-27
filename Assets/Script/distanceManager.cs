using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceManager : MonoBehaviour {
    public GameObject m_Player;
    public GameObject[] m_Star;
    public int starCount;
    public int[] answerOrder;
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
            ///Debug.Log("Mouse is Down");
            //Beware of the usage of 2D component
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitInfo.collider != null)
            {
                //Debug.Log("Hit" + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Star")
                {
                    Debug.Log("Hit" + hitInfo.transform.gameObject.name);
                }
                else if (hitInfo.transform.gameObject.tag == "Player")
                {
                    hitInfo.transform.gameObject.GetComponent<PlayerBehave>().SendSignal();
                }
                else
                {
                    Debug.Log("It didn't hit anything");
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
    }
}
