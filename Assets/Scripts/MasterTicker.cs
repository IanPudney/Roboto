using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using IronPython.Runtime;

public class MasterTicker : MonoBehaviour {
	public static MasterTicker main;
	Text text;

	// TODO(ddrocco): Should be two controllers, both of which must be ready.
	public ControllerInputManager input;

	public List<ControllerInputHandler> handlers = new List<ControllerInputHandler>();

	enum State {
		running,
		waiting,
	};
	State state;

	int _ticks;
	public int ticks {
		get {
			return _ticks;
		}
		set {
			_ticks = value;
			SetText();
		}
	}
	int max_ticks;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		main = FindObjectOfType<MasterTicker>();
		// TODO(ddrocco): Find a more elegant way of handling this.
		if (!input) {
			input = FindObjectOfType<ControllerInputManager>();
		}

		state = State.waiting;
		ticks = 0;
		max_ticks = 300;
	}

	void FixedUpdate() {
		if (state == State.waiting) {
			if (input.sfeed) {
				state = State.running;
				input._TimerStartOfStream();
				foreach (ControllerInputHandler handler in handlers) {
					handler.Playback();
				}
			}
		} else {
			if (ticks > max_ticks) {
				input._TimerEndOfStream(ticks);
				ticks = 0;
				state = State.waiting;
			} else {
				ticks += 1;
				foreach (ControllerInputHandler handler in handlers) {
					handler._TimerUpdateStep(ticks);
				}
			}
		}
	}

	void SetText() {
		text.text = _ticks.ToString("0000");
	}
}
