using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    // Propeller speed
    private float propeller = 1500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make rotates the propeller every frame around the Z axis
        transform.Rotate(Vector3.forward * Time.deltaTime * propeller);
    }
}
