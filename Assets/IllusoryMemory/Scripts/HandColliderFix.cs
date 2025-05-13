using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HandColliderFix : MonoBehaviour
{
    bool _isCollidersListComplete = false;
    GameObject _capsules;
    List<GameObject> _colliders = new List<GameObject>();

    void Update()
    {
        if (_capsules == null)
        {
            Transform capsuleTransform = transform.Find("Capsules");
            if (capsuleTransform != null)
            {
                _capsules = capsuleTransform.gameObject;
            }
        }

        if (_capsules != null && !_isCollidersListComplete)
        {
            _isCollidersListComplete = true;
            for (int i = 0; i < _capsules.transform.childCount; i++)
            {
                for (int j = 0; j < _capsules.transform.GetChild(i).childCount; j++)
                {
                    _colliders.Add(_capsules.transform.GetChild(i).GetChild(j).gameObject);
                }
            }
            EnabledCollidHand();
        }
    }

    void EnabledCollidHand()
    {
        for(int i = 0; i < _colliders.Count; i++)
        {
            _colliders[i].GetComponent<CapsuleCollider>().isTrigger = true;
            /*if (_colliders[i].name != "HandIndex3-HandIndexTip CapsuleCollider")
                _colliders[i].SetActive(false);*/
        }
    }
}
