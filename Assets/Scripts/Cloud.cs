using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    private float horizontalSpeed;

	// Use this for initialization
	void Start () {
        print("lossy scale" + transform.lossyScale);
        print("local scale" + transform.localScale);
        ///Determine how to grab the X component of the scale, then make a determination on horizontal speed.    
        
	}
	
	// Update is called once per frame
	void Update () {
		//Translate position to the right based on speed and time.
	}
}
