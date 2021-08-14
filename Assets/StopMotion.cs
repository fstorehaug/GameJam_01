using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMotion : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.velocity = Vector3.zero;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
