using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
//Depends on the shape of our sprite, it can either be a box collider or a sphere collider
[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(Collider2D))]

public class StarBehave : MonoBehaviour {

    AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
        tag = "Star";
        m_AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound()
    {
        //there is another funciton of Playoneshot, which can input a clip and the volume
        m_AudioSource.Play();
    }
}
