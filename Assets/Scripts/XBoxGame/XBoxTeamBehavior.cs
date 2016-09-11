using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class XBoxTeamBehavior : MonoBehaviour {
	public TeamUtil.Team team = TeamUtil.Team.Red;
	Renderer render;

	// Use this for initialization
	void Start () {
		render = gameObject.GetComponent<Renderer>();
		render.material.color = TeamUtil.GetColorByTeam(team);
	}
}
