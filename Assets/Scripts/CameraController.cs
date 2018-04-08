using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float cameraYDefaultPosition;
    public float cameraYMaxPosition;
    public float cameraXOffsetFromPlayer;
    private GameObject player;
    private float playerXPosition;
    //private float playerYPosition;


    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        FindPlayerPosition();
	}
	

	void Update ()
    {
        FindPlayerPosition();
        MoveCamera();
    }

    void FindPlayerPosition()
    {
        playerXPosition = player.transform.position.x;
    }

    void MoveCamera()
    {
        transform.position = new Vector3(playerXPosition+cameraXOffsetFromPlayer, cameraYDefaultPosition, -10);
    }
}
