using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorller : MonoBehaviour
{
    public GameObject player;
    private Vector3 destination;

    void FixedUpdate()
    {
        destination = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime);
    }
}
