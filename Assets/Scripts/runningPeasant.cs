using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningPeasant : MonoBehaviour
{
    float speed = 4f;
    float runningTimer = 10;

    void Update()
    {
        runningTimer -= Time.deltaTime;
        if (runningTimer > 0) {transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
        else
        {
            transform.Rotate(Vector3.up, 180);
            runningTimer = 10;

        }
    }
}
