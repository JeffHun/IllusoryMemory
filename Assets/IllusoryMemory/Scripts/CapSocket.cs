using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapSocket : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cap")
        {
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.position = this.gameObject.transform.position;
            other.gameObject.transform.rotation = this.gameObject.transform.rotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cap")
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.transform.parent = null;
        }
    }
}
