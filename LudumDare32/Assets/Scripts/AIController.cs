using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

	Vector3 movement;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("AddForceToPeasant", 0f, 2.0f);
		movement = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

//		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation (movement), Time.deltaTime * 10f);		
//		Debug.Log (movement);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation (new Vector3(movement.x, 0f, movement.z)), Time.deltaTime * 10f);
		transform.Translate (movement * Random.Range(5f, 10f) * Time.deltaTime, Space.Self);
	}

	void AddForceToPeasant(){
	
		movement = new Vector3 (Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f), 0.0f);
	}

	void OnParticleCollision(GameObject other) {
		GetComponentInChildren<Animator>().SetBool("inPanic", true);
	}
}
