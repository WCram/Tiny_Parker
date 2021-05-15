using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Around : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        transform.Translate(Vector3.forward * (Input.GetAxisRaw("Vertical") * Time.deltaTime * 20f));
        transform.Translate(Vector3.right * (Input.GetAxisRaw("Horizontal") * Time.deltaTime * 20f));

        transform.Rotate(Vector3.up * (Time.deltaTime * Input.GetAxisRaw("Mouse X") * 40f));
        transform.Rotate(Vector3.left * (Time.deltaTime * Input.GetAxisRaw("Mouse Y") * 40f));

    }
}
