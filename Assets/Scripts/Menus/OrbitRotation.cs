using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitRotation : MonoBehaviour
{
    float rotationSpeed = 150f;
    private void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
    }

}
