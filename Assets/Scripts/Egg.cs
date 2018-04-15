using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {

    public float hatchDelayTime;
    public float creditsDelayTime;
    public Camera cam;

    private PlayerController pc;
    private Animator camAnimator;
    private Animator eggAnimator;
    private LevelManager levelManager;
    private AudioSource audioSource;
    
    // Use this for initialization
	void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
        camAnimator = cam.GetComponent<Animator>();
        eggAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        pc = FindObjectOfType<PlayerController>();

	}
	


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BeginHatching();
        }
    }

    private void BeginHatching()
    {
        ZoomInOnEgg();
        Invoke("HatchMyEgg", hatchDelayTime);
    }

    private void ZoomInOnEgg()
    {
        camAnimator.SetTrigger("Zoom");

    }

    private void HatchMyEgg()
    {
        pc.DisablePlayerInput();
        eggAnimator.SetTrigger("triggerHatch");
        audioSource.Play();
    }

    public void StopHatchingSound()
    {
        audioSource.loop = false;
        Invoke("RollCredits", creditsDelayTime);
    }

    private void RollCredits()
    {
        levelManager.LoadLevel("Credits");
    }

}
