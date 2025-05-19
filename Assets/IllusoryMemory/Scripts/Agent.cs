using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Agent : MonoBehaviour
{
    [SerializeField]
    Transform _startPoint, _endPoint;

    [SerializeField]
    float _speed = 2.0f, _waitDuration;

    Animator _animator;
    bool _isAnimStart = true;
    bool _isAnimated = false;
    float _lerpTime = 0f;
    AnimState agentState = AnimState.enter;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAgentAnim()
    {
        _isAnimStart = true;
        agentState = AnimState.enter;
    }

    void Update()
    {
        if(_isAnimStart)
        {
            if(agentState == AnimState.enter)
            {
                if(_isAnimated == false)
                {
                    _animator.Play("Walk");
                    _isAnimated = true;
                }
                _lerpTime += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(_startPoint.position, _endPoint.position, _lerpTime);
                if(_lerpTime >= 1)
                {
                    agentState = AnimState.firstTurn;
                    _lerpTime = 0;
                    _isAnimated = false;
                }
            }

            if(agentState == AnimState.firstTurn)
            {
                if (_isAnimated == false)
                {
                    _animator.Play("Turn");
                    _isAnimated = true;
                }
                AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

                if (stateInfo.IsName("Turn") && stateInfo.normalizedTime >= 1f)
                {
                    transform.Rotate(0f, -90f, 0f);
                    agentState = AnimState.wait;
                    _isAnimated = false;
                }
            }

            if (agentState == AnimState.wait)
            {
                if (_isAnimated == false)
                {
                    _animator.Play("Wait");
                    _isAnimated = true;
                }
                _lerpTime += Time.deltaTime;
                if(_lerpTime >= _waitDuration)
                {
                    _lerpTime = 0;
                    agentState = AnimState.secondTurn;
                    _isAnimated = false;
                }
            }

            if (agentState == AnimState.secondTurn)
            {
                if (_isAnimated == false)
                {
                    _animator.Play("Turn");
                    _isAnimated = true;
                }
                AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

                if (stateInfo.IsName("Turn") && stateInfo.normalizedTime >= 1f)
                {
                    transform.Rotate(0f, -90f, 0f);
                    agentState = AnimState.exit;
                    _isAnimated = false;
                }
            }

            if (agentState == AnimState.exit)
            {
                if (_isAnimated == false)
                {
                    _animator.Play("Walk");
                    _isAnimated = true;
                }
                _lerpTime += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(_endPoint.position, _startPoint.position, _lerpTime);
                if (_lerpTime >= 1)
                {
                    agentState = AnimState.none;
                    _lerpTime = 0;
                    _isAnimated = false;
                    transform.Rotate(0f, 180f, 0f);
                }
            }
        }
    }

    public enum AnimState
    {
        none,
        enter,
        firstTurn,
        wait,
        secondTurn,
        exit
    }
}
