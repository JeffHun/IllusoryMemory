using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coffee"))
        {
            other.gameObject.transform.parent = null;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
