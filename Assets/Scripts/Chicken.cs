using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //trigger animation
            //play sound
            //audioSource.Play();
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.InteractWithChicken();
        }

    }
}
