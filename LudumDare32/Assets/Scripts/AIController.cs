using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

	Vector3 movement;

	float movementSpeed;

	float livingTime = 0;
	bool isInPanic = false;

	// Use this for initialization
	void Start () {
		InvokeRepeating("AddForceToPeasant", 0f, 2.0f);
		movement = Vector3.zero;
		movementSpeed = Random.Range(1f, 3f);

		livingTime = 6f;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log(livingTime);
//		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation (movement), Time.deltaTime * 10f);		
//		Debug.Log (movement);

		if(livingTime > 0)
		{
			if(isInPanic){
				livingTime -= Time.deltaTime;
			}
		}
		if(livingTime <= 0)
		{
			movement = Vector3.zero;
			Destroy(transform.gameObject);


		}else{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation (new Vector3(movement.x, 0f, movement.z)), Time.deltaTime * 10f);
			transform.Translate (movement * movementSpeed * Time.deltaTime, Space.Self);
		}
	}

	void AddForceToPeasant(){
	
		movement = new Vector3 (Random.Range(-1.0f,1.0f), 0.0f, Random.Range(-1.0f,1.0f));
	}

	void OnParticleCollision(GameObject other) {
		isInPanic = true;

		GetComponentInChildren<Animator>().SetBool("inPanic", true);
		movementSpeed = Random.Range(6f, 12f);

		GetComponentsInChildren<Light>()[0].enabled = true;
		GetComponentsInChildren<Light>()[1].enabled = true;
		livingTime = 6f;


	}
}
