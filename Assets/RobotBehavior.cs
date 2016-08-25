using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RobotActionCommand {
	public virtual void Command() {}
}

public class ForwardCommand : RobotActionCommand {
	public override void Command() {
		return;
	}
}

public class RobotBehavior : MonoBehaviour {

	List<RobotActionCommand> commands = new List<RobotActionCommand>();
	int current_command;
	public float force_const = 50f;


	// Use this for initialization
	void Start () {
		current_command = 0;
		commands.Add(new ForwardCommand());
	}
	
	// Update is called once per frame
	void Update () {
		commands[current_command].Command();
		this.GetComponent<Rigidbody>().AddForce(force_const * Time.deltaTime * transform.forward);
	}
}
