using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAIController : MonoBehaviour {

	public Transform player;
	public float playerDistance;
	public float awareAI = 10f;
	public float AIMoveSpeed;
	public float damping = 6.0f;
	
	public Transform[] navPoint;
	public NavMeshAgent agent;
	public int destPoint = 0;
	public Transform goal;


	
	void Start () 
    {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position; 

		agent.autoBraking = false;
		
	}
	
	void Update () 
    {
        
		playerDistance = Vector3.Distance (player.position, this.transform.position);
        Vector3 direction = player.position - this.transform.position;
		if (playerDistance < awareAI)
		{
            Debug.Log("I'm aware");
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
			LookAtPlayer();
            Chase();
		}

		if (playerDistance < awareAI)
		{
			if (playerDistance < 10f)
			{ 
                SceneManager.LoadScene("Game Over");
			}
				else
			GotoNextPoint();		
		}
		
		
		if (agent.remainingDistance < 0.5f)
				GotoNextPoint();	

	}
	
	void LookAtPlayer()
	{
		transform.LookAt(player);	
	}

	
	void GotoNextPoint()
		{
			if (navPoint.Length == 0)
				return;       
			agent.destination = navPoint[destPoint].position;
			destPoint = (destPoint + 1) % navPoint.Length;
		}
	
		
		void Chase ()
		{
			transform.Translate (Vector3.forward * AIMoveSpeed * Time.deltaTime);
		}
	}