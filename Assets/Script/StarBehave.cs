using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
//Depends on the shape of our sprite, it can either be a box collider or a sphere collider
[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(Collider2D))]

public class StarBehave : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        tag = "Star";	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
