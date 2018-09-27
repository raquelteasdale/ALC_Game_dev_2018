using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	// Movement Variables
	public float MoveSpeed;
	public bool MoveRight;
	
	// Wall Check
	public float WallCheckRadius;
	public LayerMask WhatIsWall;
	private bool HittingWall;
	
	// Edge Check
	private bool NotAtaEdge;
	public Transform EdgeCheck;

	
	// Update is called once per frame
	void Update () {
		NotAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);
		
		HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);
		
		if (Hittingwall || !NotAtEdge){
			MoveRight = !MoveRight;
		}

		if (MoveRight){
			transform.localScale = new Vector3(-0.2f,0.2f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody>().velocity.y);
		}
		else {
			transform.localScale = new Vector3(0.2f,0.2f,1f);
			GetComponent<Rididbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody>().velocity.y);
		}
	}
}
