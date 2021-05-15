using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Vector3 impulse = new Vector3(.5f, 0.5f, 0.0f);
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
        }
    }
}
