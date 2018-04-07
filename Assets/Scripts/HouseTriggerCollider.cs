using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTriggerCollider : MonoBehaviour {

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            levelManager.LoadLevel("House");
        }
    }
}
    