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

public class ControllerInputManager : MonoBehaviour
{
	// Object references.
	private InputDevice device;

	// Whether to use the mouse for controls.
	private bool debugControls = false;

	public float lfeed;
	public float rfeed;
	public bool afeed;
	public bool Sfeed;

	void Awake()
	{
		lfeed = 0f;
		rfeed = 0f;
		afeed = false;
		Sfeed = false;

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
		if (device.Action3.WasPressed) // X button on Xbox
		{
			afeed = true;
		} else {
			afeed = false;
		}

		// Change states based on controller input
		if (device.Action1.WasPressed) // A? button on Xbox
		{
			Sfeed = true;
		} else {
			Sfeed = false;
		}
	}

	void CheckDebugStates()
	{
	}

	// Sets the player's movement direction based on controller left stick input
	// Called in update, so controller input is registered as quickly as possible
	void SetMoveDirection()
	{

	}
}