using UnityEngine;
using System.Collections;

public class TankbotSlugBehavior : MonoBehaviour {
	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.AddForce(transform.up * -50f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
