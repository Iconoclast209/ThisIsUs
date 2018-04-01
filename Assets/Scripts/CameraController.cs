using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float cameraYDefaultPosition;
    public float cameraYMaxPosition;
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
        //playerYPosition = player.transform.position.y;
        print("Player X Position = " + playerXPosition.ToString());
    }

    void MoveCamera()
    {
        transform.position = new Vector3(playerXPosition, cameraYDefaultPosition, -10);
    }
}
