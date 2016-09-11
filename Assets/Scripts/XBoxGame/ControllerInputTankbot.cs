using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using System.Collections.Generic;
using UnityEngine.UI;

public class ControllerInputTankbot : ControllerInputHandler {

	public GameObject tankbot_body_prefab;
	public GameObject tankbot_bullet_prefab;

	Rigidbody TankbotRigidbody;
	int tankbot_health;

	float left_tread;
	float right_tread;
	bool fire_action_taken;

	int cannon_load_cooldown;
	bool cannon_loaded {
		get {
			return cannon_load_cooldown == 0;
		}
		set {
			if (value) {
				cannon_load_cooldown = 0;
			} else {
				cannon_load_cooldown = 200;
			}
		}
	}

	int _fire_animation_remaining;
	bool fire_animation_playing {
		get {
			return _fire_animation_remaining > 0;
		}
		set {
			if (value) {
				_fire_animation_remaining = 20;
			} else {
				_fire_animation_remaining = 0;
			}
		}
	}

	enum Robo_state {
		driving,
		firing,
		dead,
	};
	Robo_state robo_state;

	// Use this for initialization
	new protected void Start () {
		GameObject TankbotBody = Instantiate(tankbot_body_prefab) as GameObject;
		TankbotRigidbody = TankbotBody.GetComponent<Rigidbody>();
		TankbotRigidbody.transform.SetParent(transform);
		CleanupPositions();
		base.Start();
	}

	override protected void LAct(float y) {
		left_tread = y;
	}

	override protected void RAct(float y) {
		right_tread = y;
	}

	override protected void AAct(bool y) {
		fire_action_taken = y;
	}

	override protected void ResolveActions() {
		// Debug.Log(TankbotRigidbody.velocity);
		if (!cannon_loaded) {
			--cannon_load_cooldown;
		}
		Debug.Log(robo_state);
		switch (robo_state){
		case Robo_state.driving:
			if (fire_action_taken && cannon_loaded) {
				FireCannon();
				return;
			}
			// Debug.Log("Tankbot" + id + ": (" + left_tread + "," + right_tread + ")");
			TankbotRigidbody.AddRelativeForce(5f * new Vector3(0, 0, left_tread + right_tread));
			TankbotRigidbody.AddTorque(new Vector3(0, 0, right_tread - left_tread));
			break;
		case Robo_state.firing:
			if (fire_animation_playing) {
				--_fire_animation_remaining;
				return;
			} else {
				robo_state = Robo_state.driving;
			}
			break;
		case Robo_state.dead:
			return;
		}
	}

	override public void CleanupPositions() {
		TankbotRigidbody.transform.localPosition = Vector3.zero;
		TankbotRigidbody.transform.localEulerAngles = new Vector3(270, 0, 0);
		TankbotRigidbody.ResetInertiaTensor();
		tankbot_health = 10;
		robo_state = Robo_state.driving;
		fire_animation_playing = false;
		cannon_loaded = true;
	}

	// Private, unique

	void FireCannon() {
		robo_state = Robo_state.firing;
		cannon_loaded = false;
		fire_animation_playing = true;
	}
}
