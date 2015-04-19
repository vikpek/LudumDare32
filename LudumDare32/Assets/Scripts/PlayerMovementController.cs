using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
	Transform myTransform;
	float destinationDistance;
	[SerializeField]
	float
		moveSpeed;
	float horizontalInput;
	float verticalInput;
	public float fireRate = 0.5f;
	private float nextFire = 0.0f;
	private float resetTimer = 1f;
	
	void Start ()
	{
		myTransform = transform;							
	}
	
	void FixedUpdate ()
	{
		horizontalInput = Input.GetAxis ("Horizontal"); 
		verticalInput = Input.GetAxis ("Vertical"); 

		Vector3 movement = new Vector3 (horizontalInput, 0.0f, verticalInput);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation (movement), Time.deltaTime * 10f);

		transform.Translate (movement * moveSpeed * Time.deltaTime, Space.World);

		if(horizontalInput > 0.1f || verticalInput > 0.1f){
			GetComponentInChildren<Animator>().SetBool("running", true);
		}else{
			GetComponentInChildren<Animator>().SetBool("running", false);
		}

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {

			nextFire = Time.time + fireRate;

			Plane playerPlane = new Plane (Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float hitdist = 0.0f;



			if (playerPlane.Raycast (ray, out hitdist)) {

				float distance = Vector3.Distance(transform.position, ray.GetPoint (hitdist));
//				Debug.Log(distance);
				if(distance<15f){
					GameObject go = (GameObject)Instantiate ((GameObject)Resources.Load ("Projectile"), transform.position + Vector3.up, transform.rotation);
					ProjectileMovementController pmc = go.transform.GetComponent<ProjectileMovementController> ();
					pmc.setTarget (ray.GetPoint (hitdist));
					resetTimer = 1;
				}else{

				}
			}
		}	

	}
}
