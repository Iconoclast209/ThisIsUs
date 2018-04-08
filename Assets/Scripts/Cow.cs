using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour {

    private Animator animCow;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        animCow = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //trigger animation
            animCow.SetTrigger("triggerMoo");
            //play sound
            audioSource.Play();
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.InteractWithCow();
        }

    }
}
