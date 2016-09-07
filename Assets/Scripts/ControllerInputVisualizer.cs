using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using XInputDotNetPure;

public class ControllerInputVisualizer : MonoBehaviour {

	ControllerInputManager input;
	Queue<float> lstream;
	Queue<float> rstream;
	Queue<bool> astream;
	int steps;
	int total_steps;

	public GameObject visualizer_prefab;

	Transform LVisualizer;
	Transform RVisualizer;
	Renderer AVisualizer;

	bool state;

	// Use this for initialization
	void Start () {
		input = GetComponent<ControllerInputManager>();
		GameObject LObject = Instantiate(visualizer_prefab) as GameObject;
		LVisualizer = LObject.transform;
		GameObject RObject = Instantiate(visualizer_prefab) as GameObject;
		RVisualizer = RObject.transform;
		GameObject AObject = Instantiate(visualizer_prefab) as GameObject;
		AVisualizer = AObject.GetComponent<Renderer>();

		InitializePrimitives();

		lstream = new Queue<float>();
		rstream = new Queue<float>();
		astream = new Queue<bool>();
	}

	void Update() {
		if (state && input.Sfeed) {
			state = false;
			total_steps = steps ;
			steps = 0;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		steps += 1;
		MasterTicker.main.ticks = steps;

		if (!state) {
			if (steps < total_steps) {
				LAct(lstream.Dequeue());
				RAct(rstream.Dequeue());
				AAct(astream.Dequeue());
				return;
			} else {
				Debug.Log(total_steps + " taken; resetting...");
				InitializePrimitives();
			}
		}

		LAct(input.lfeed);
		RAct(input.rfeed);
		AAct(input.afeed);
		lstream.Enqueue(input.lfeed);
		rstream.Enqueue(input.rfeed);
		astream.Enqueue(input.afeed);
	}

	void LAct(float y) {
		LVisualizer.transform.localPosition = new Vector3(-1, y, 0);
	}

	void RAct(float y) {
		RVisualizer.transform.localPosition = new Vector3(1, y, 0);
	}

	void AAct(bool y) {
		AVisualizer.enabled = y;
	}

	void InitializePrimitives() {
		state = true;
		steps = 0;
	}
}
