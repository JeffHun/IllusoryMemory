using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCard : MonoBehaviour
{
    float _speed = .25f;
    bool _isTouched = false;
    GameObject _finger;
    int _elapsedFrames = 0;
    int _interpolationFramesCount = 200;
    float _yPos;

    private void Start()
    {
        _yPos = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "HandIndex3-HandIndexTip CapsuleCollider")
        {
            _isTouched = true;
            _finger = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Card")
        {
            Vector3 direction = other.transform.position - transform.position;
            Vector3 desiredVelocity = direction.normalized * _speed;
            Vector3 deltaVelocity = desiredVelocity - other.GetComponent<Rigidbody>().velocity;
            Vector3 force = deltaVelocity / Time.fixedDeltaTime;
            other.GetComponent<Rigidbody>().AddForce(force, ForceMode.Acceleration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "HandIndex3-HandIndexTip CapsuleCollider")
        {
            _isTouched = false;
        }
        if (other.gameObject.tag == "Card")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_isTouched)
        {
            float interpolationRatio = (float)_elapsedFrames / _interpolationFramesCount;
            Vector3 targetPosition = new Vector3(_finger.transform.position.x, _yPos, _finger.transform.position.z);
            Vector3 interpolatedPosition = Vector3.Lerp(transform.position, targetPosition, interpolationRatio);
            transform.position = interpolatedPosition;
            _elapsedFrames = (_elapsedFrames + 1) % (_interpolationFramesCount + 1);
        }
        else
            GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
