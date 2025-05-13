using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Agent : MonoBehaviour
{
    [SerializeField]
    Transform _startPoint, _endPoint;

    [SerializeField]
    float _speed = 2.0f;

    Animator _animator;
    bool isEntering = false, isFirstTurning = false, isSecondTurning = false, isExiting = false;
    float _lerpTime = 0f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Enter"))
        {
            if (!isEntering)
            {
                isEntering = true;
                _lerpTime = 0f;
            }

            _lerpTime += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_startPoint.position, _endPoint.position, _lerpTime);
        }
        if (stateInfo.IsName("Wait") && !isFirstTurning)
        {
            isFirstTurning = true;
            transform.Rotate(0f, -90f, 0f);
        }
        if(stateInfo.IsName("Exit") && !isSecondTurning)
        {
            isSecondTurning= true;
            transform.Rotate(0f, -90f, 0f);
        }
        
        if (stateInfo.IsName("Exit"))
        {
            if (!isExiting)
            {
                isExiting = true;
                _lerpTime = 0f;
            }
            _lerpTime += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_endPoint.position, _startPoint.position, _lerpTime);
        }
    }
}
