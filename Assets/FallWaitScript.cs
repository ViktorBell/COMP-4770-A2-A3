using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FallWaitScript : MonoBehaviour
{

    Rigidbody rb;

    int sleepCounter = 1000;

    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        rb.Sleep();
        
    }

    // Update is called once per frame
    void Update()
    {



        if (sleepCounter > 0)
        {

            rb.Sleep();

            sleepCounter--;

        }
        else {
            rb.WakeUp();
        }


        
    }
}
