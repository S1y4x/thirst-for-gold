using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    bool IsActive = true;
    void Update()
    {
        if (IsActive)
        {
            if (transform.localRotation == Quaternion.Euler(0, 260, 0))
            {
                IsActive = false;
            }
            else transform.Rotate(Vector3.up * 0.3f);
            
        }       
    }
}
