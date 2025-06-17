using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCButton : MonoBehaviour
{
    [SerializeField]
    List<Material> _mats = new List<Material>();
    bool _isTurnOn = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "HandIndex3-HandIndexTip CapsuleCollider")
        {
            _isTurnOn = !_isTurnOn;
            GetComponent<MeshRenderer>().material = _mats[_isTurnOn?0:1];
        }
    }
}
