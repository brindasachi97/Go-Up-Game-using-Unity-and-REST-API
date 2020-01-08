using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object
    public GameObject rightWall;
    public GameObject leftWall;

    [Range(0.0f, 10.0f)]
    public double rightOffset;

    [Range(0.0f, 10.0f)]
    public double leftOffset;

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
    private float x;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (player.transform.position.x + rightOffset < rightWall.transform.position.x &&
            player.transform.position.x - leftOffset > leftWall.transform.position.x)
        {
            //transform.position = player.transform.position.x + offset.x;
            x = player.transform.position.x + offset.x;
        }

        transform.position = new Vector3(x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
    }
}

