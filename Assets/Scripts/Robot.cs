using UnityEngine;
using System.Collections;
using System.Threading;

public class Robot : MonoBehaviour {
    public float _speed = 3.0f; 
    public float speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void drive(float distance)
    {
        MainThread.main.waitCoroutine(driveCoroutine(distance));
    }

    IEnumerator driveCoroutine(float distance)
    {
        yield return null;
        float distance_accum = 0;
        while(distance_accum < distance)
        {
            transform.localPosition += transform.forward * Time.deltaTime * speed;
            distance_accum += Time.deltaTime * speed;
            yield return null;
        }
    }


}
