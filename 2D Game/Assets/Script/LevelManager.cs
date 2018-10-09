using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D PC;

	// Particles

	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	// Respawn Delay

	public float RespawnDelay;

	private CameraController CameraFollow;

	// Point Penalty on Death

	public int PointPenaltyOnDeath;

	// Store Gravity Value
	
	private float GravityScore;

	// Use this for initialization
	void Start () {
        // PC = FindObjectOfType<Rigidbody2D> ();

		CameraFollow = FindObjectOfType<CameraController>();
	}
	
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}
	
	public IEnumerator RespawnPlayerCo(){
		// Generate Death Particle
		Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);
		// Hide PC
		// PC.enabled = false;
		PC.GetComponent<Renderer> ().enabled = false;
		CameraFollow.isFollowing = false;
		// Gravity Reset

		// GravityScore = PC.GetComponent<Rigidbody2D>().gravityScale;
		// PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
		// PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		// Debug Message
		Debug.Log ("PC Respawn");
		// Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		// Gravity Restore

		// PC.GetComponent<Rigidbody2D>().gravityScale = GravityScore;

		// Match PCs transform position
		PC.transform.position = CurrentCheckPoint.transform.position;
		// Show PC
		// PC.enabled = true;
		PC.GetComponent<Renderer> ().enabled = true;
		// Spawn PC
		CameraFollow.isFollowing = true;
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}
