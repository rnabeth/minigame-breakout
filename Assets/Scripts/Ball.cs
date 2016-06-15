using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	public float ballInitialVelocity = 600f;

	private Rigidbody rb;
	private bool ballInPlay;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
		//NOTE: For repeated physics FixedUpdate is better, but this will happen only once
		if (Input.GetButtonDown("Fire1") && !ballInPlay) {
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		}
	}
}
