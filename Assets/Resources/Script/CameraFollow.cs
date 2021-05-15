using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    public float offsetX = 0;
    public float offsetY = 0;
    public float offsetZ = 0;

    private void FixedUpdate()
    {
        Vector3 pos = player.position;
        transform.position = new Vector3(pos.x + offsetX, pos.y + offsetY, pos.z + offsetZ);
    }
} // class
