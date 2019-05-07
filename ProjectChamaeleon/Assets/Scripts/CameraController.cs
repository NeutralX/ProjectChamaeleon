using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Transform target;//Public variable to store a reference to the player game object

    public float xMax;
    public float yMax;
    public float xMin;
    public float yMin;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        //target = GameObject.Find("Player").transform;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
        //transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax),Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }
}
