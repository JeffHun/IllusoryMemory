using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light _light;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "HandIndex3-HandIndexTip CapsuleCollider")
        {
            if(_light.intensity == 1)
                _light.intensity = 0;
            else
                _light.intensity = 1;
        }
    }
}
