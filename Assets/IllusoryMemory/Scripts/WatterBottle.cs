using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatterBottle : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _waterPS;
    [SerializeField]
    GameObject _capSocket;
    [SerializeField]
    float _angleMax = 90f;
    [SerializeField]
    AudioSource _audioSource;

    float _minTiltAngle = 270f;
    float _maxTiltAngle = 90f;

    Quaternion _initRot;
    bool _isSoundPLayed;

    private void Start()
    {
        _initRot = Quaternion.Euler(0f, 0f, 0f);
    }

    void Update()
    {
        if (_capSocket.transform.childCount == 0)
        {
            Quaternion currentRot = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, transform.rotation.eulerAngles.z);

            float angleRotation = Quaternion.Angle(_initRot, currentRot);

            if (angleRotation > _angleMax)
            {
                _waterPS.Play();
            }
            else
            {
                _waterPS.Stop();
                _isSoundPLayed = false;
            }
        }
        else
        {
            _waterPS.Stop();
            _isSoundPLayed = false;
        }

        if (_isSoundPLayed == false)
        {
            _audioSource.Stop();
        }

        if (_waterPS.isPlaying && _isSoundPLayed == false)
        {
            _isSoundPLayed = true;
            _audioSource.Play();
        }
    }
}
