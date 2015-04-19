using UnityEngine;
using System.Collections;

public class ProjectileMovementController : MonoBehaviour {
	[SerializeField]
	float speed = 1.5f;
	Vector3 target;

	[SerializeField]
	float explosionTime = 3f;

	bool targetSet = false;

	void Start()
	{
		transform.GetComponent<ConstantForce>().relativeTorque = new Vector3(Random.Range(0.0f, 0.7f), Random.Range(0.0f, 0.7f), Random.Range(0.0f, 0.7f));
		transform.GetComponent<ConstantForce>().relativeForce = new Vector3(0f, 1f, 1f);
	}

	void FixedUpdate () {


		transformToPosition ();

		calculateExplosion ();

	}

	void calculateExplosion ()
	{
		if (Vector3.Distance (transform.position, target) < 0.1f) {
			GetComponentInChildren<ParticleSystem>().Play();
			if(!GetComponentInChildren<AudioSource>().isPlaying){
				GetComponentInChildren<AudioSource>().Play();
			}
			explosionTime -= Time.deltaTime;
			if(explosionTime < 0)
			{
				Destroy(transform.gameObject);
			}

		}
	}

	void transformToPosition ()
	{
		if (targetSet) {
			transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
	}

	public void setTarget(Vector3 target_)
	{

		targetSet = true;
		target = target_;
	}
	

}