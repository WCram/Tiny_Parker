using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float turnSpeed = 2;
    [SerializeField] private float acceleration = 1;
    [SerializeField] private float maxSpeed = 20;
    [SerializeField] private float shinkSize = .2f;
    [SerializeField] private GameObject icon;
    
    [SerializeField]private float speed = 0;
    private bool isShrunk = false;
    private float origSize = 1;
    
    public float Speed { get => speed; set => speed = value; }
    
    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0 )
        {
            if (speed < maxSpeed)
            {
                if(speed >= 0) speed += acceleration * Time.deltaTime;
                else if ( speed < 0) speed += acceleration * Time.deltaTime * 10;
            }
        }

        if (Input.GetAxisRaw("Vertical") < 0 && speed > -maxSpeed)
        {
            speed -= acceleration * Time.deltaTime * 2;
        }
        
        if (Input.GetAxis("Vertical") == 0 && speed != 0)
        {
            if (speed > 0)
            {
                speed -= acceleration * Time.deltaTime * 3;
            }
            else
            {
                speed += acceleration * Time.deltaTime;
            }
        }
        
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        transform.Rotate(Vector3.up * (Time.deltaTime * Input.GetAxisRaw("Horizontal") * turnSpeed));
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 loc = transform.position;

            if (!isShrunk)
            {
                transform.localScale = new Vector3(shinkSize, shinkSize, shinkSize);
                icon.SetActive(true);
                isShrunk = true;
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                icon.SetActive(false);
                isShrunk = false;
            }
            transform.position = new Vector3(loc.x, 0, loc.z);
        }
        
 
    } // Update()
    
} // class
