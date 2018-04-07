using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    public float bigCloudSpeed;
    public float mediumCloudSpeed;
    public float smallCloudSpeed;
    private float horizontalSpeed;

    // Use this for initialization
    void Start()
    {
        if (transform.localScale.x >= 0.9)
        {
            horizontalSpeed = bigCloudSpeed;
        }
        else if (transform.localScale.x >= 0.5)
        {
            horizontalSpeed = mediumCloudSpeed;
        }
        else
        {
            horizontalSpeed = smallCloudSpeed;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Translate position to the right based on speed and time.
        transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
	}
}
