using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixVelocity : MonoBehaviour
{
    float _maxVelocity = 2;

    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.x > _maxVelocity ||
            GetComponent<Rigidbody>().velocity.y > _maxVelocity ||
            GetComponent<Rigidbody>().velocity.z > _maxVelocity ||
            GetComponent<Rigidbody>().velocity.x < -_maxVelocity ||
            GetComponent<Rigidbody>().velocity.y < -_maxVelocity ||
            GetComponent<Rigidbody>().velocity.z < -_maxVelocity)
            GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
