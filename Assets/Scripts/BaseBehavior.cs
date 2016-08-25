using UnityEngine;
using System.Collections;

public class BaseBehavior : MonoBehaviour {
	public TeamUtil.Team team = TeamUtil.Team.Red;

	ParticleSystem system;

	// Use this for initialization
	void Start () {
		system = GetComponentInChildren<ParticleSystem>();
		system.startColor = TeamUtil.GetColorByTeam(team);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
