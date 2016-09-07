using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MasterTicker : MonoBehaviour {
	public static MasterTicker main;
	Text text;

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

	// Use this for initialization
	void Start () {
		_ticks = 0;
		text = GetComponent<Text>();
		main = FindObjectOfType<MasterTicker>();
	}

	void SetText() {
		text.text = _ticks.ToString("0000");
	}
}
