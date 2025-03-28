using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Phone")
        {
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
        }
    }
}
