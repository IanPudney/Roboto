/* DEBUGGUING KEYBOARD CONTROLS
 * 
 * IJKL - movement
 * Mouse - look around
 * Tab - switch between Stan's mouse controls and Q's mouse controls
 * Left click - interact
 * O - sprint
 * 
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;
using IronPython.Runtime;

public class ControllerInputManager : MonoBehaviour
{
	// Object references.
	private InputDevice device;

	// TODO(ddrocco): Delete this and handle creation more elegantly.
	public GameObject input_handler_prefab;

	// Current ControllerInputHandler.
	private ControllerInputHandler handler;
	private List<ControllerInputHandler> old_handlers = new List<ControllerInputHandler>();

	// Whether to use the mouse for controls.
	private bool debugControls = false;

	public float lfeed;
	public float rfeed;
	public bool afeed;
	public bool sfeed;

	void Awake()
	{
		lfeed = 0f;
		rfeed = 0f;
		afeed = false;
		sfeed = false;

		device = InputManager.ActiveDevice;

		foreach (var Device in InputManager.Devices) {
			if (Device.Name.Contains("Unknown")) {
				debugControls = true;
			}
		}
		if (InputManager.Devices.Count == 0)
			debugControls = true;

		if (debugControls)
		{
			Debug.Log("Debug controls active");
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		handler = this.NewHandler();
	}

	void Update()
	{
		if (debugControls)
		{
			// Debug methods.
			return;
		}
		lfeed = device.LeftStickY;
		rfeed = device.RightStickY;

		// Change states based on controller input
		if (device.Action3.IsPressed) // X button on Xbox
		{
			afeed = true;
		} else {
			afeed = false;
		}

		// Change states based on controller input
		if (device.Action1.IsPressed) // A? button on Xbox
		{
			sfeed = true;
		} else {
			sfeed = false;
		}
	}

	// Called by MasterTimer on the first step during FixedUpdate action.
	public void _TimerStartOfStream() {
		handler.StartOfStream();
	}

	// Called by MasterTimer on the last step during FixedUpdate action.
	public void _TimerEndOfStream(int step) {
		handler.EndOfStream(step);
		old_handlers.Add(handler);
		handler = this.NewHandler();
	}

	void CheckDebugStates()
	{
	}

	// Sets the player's movement direction based on controller left stick input
	// Called in update, so controller input is registered as quickly as possible
	void SetMoveDirection()
	{

	}

	ControllerInputHandler NewHandler() {
		GameObject new_handler_object = Instantiate(input_handler_prefab) as GameObject;
		ControllerInputHandler new_handler = new_handler_object.GetComponent<ControllerInputHandler>();
		new_handler.SetControllerInputManager(this);
		return new_handler;
	}
}