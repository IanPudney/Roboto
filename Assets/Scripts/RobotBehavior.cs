using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RobotActionCommand {
	public virtual void Command(float force, float deltatime, Vector3 dir, Rigidbody robot) {}
}

public class ForwardCommand : RobotActionCommand {
	public override void Command(float force, float deltatime, Vector3 dir, Rigidbody robot) {
		robot.AddForce(force * deltatime * dir);
	}
}

public class RobotBehavior : MonoBehaviour {
	public TeamUtil.Team team = TeamUtil.Team.Red;
	Rigidbody rigid;
	Renderer render;
	List<RobotActionCommand> commands = new List<RobotActionCommand>();
	int current_command;
	public static float force_const = 50f;


	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody>();
		render = gameObject.GetComponent<Renderer>();

		current_command = 0;
		commands.Add(new ForwardCommand());

		render.material.color = TeamUtil.GetColorByTeam(team);
	}
	
	// Update is called once per frame
	void Update () {
		commands[current_command].Command(force_const, Time.deltaTime, transform.forward, rigid);
	}
}
