using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRelocation : MonoBehaviour
{
    [SerializeField]
    string _tag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _tag)
        {
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
        }
    }
}
