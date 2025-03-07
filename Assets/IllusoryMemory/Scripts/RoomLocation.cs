using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLocation : MonoBehaviour
{
    [SerializeField] GameObject _roomPrefab;
    [SerializeField] float _translationSpeed, _rotationSpeed;
    GameObject _currentRoom;
    bool _isRoomSpawned = false;
    bool _isRoomHide = false;

    void Update()
    {
        // left trigger = spawn room
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch) && !_isRoomSpawned)
        {
            _currentRoom = Instantiate(_roomPrefab, transform.position, Quaternion.identity);
            _currentRoom.transform.parent = transform;
            _isRoomSpawned = true;
            _isRoomHide = false;
        }


        // left thumbstick = move room
        if (_isRoomSpawned)
        {
            // get controller orientation
            Quaternion leftControllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
            Vector3 forward = leftControllerRotation * Vector3.forward;
            Vector3 right = leftControllerRotation * Vector3.right;

            // disable vertical movements
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            Vector2 moveInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            _currentRoom.transform.position += (forward * moveInput.y + right * moveInput.x) * Time.deltaTime * _translationSpeed;
        }

        // right thumbstick = rotate room
        if (_isRoomSpawned)
        {
            float rotationInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;

            if (Mathf.Abs(rotationInput) > 0.1f)
            {
                Vector3 pivot = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
                RotateAround(_currentRoom, pivot, rotationInput * _rotationSpeed * Time.deltaTime);
            }
        }

        // Y = hide/expose room
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch) && _isRoomSpawned)
        {
            for (int i = 0; i < _currentRoom.transform.childCount; i++)
            {
                if (_currentRoom.transform.GetChild(i).GetComponent<MeshRenderer>())
                    _currentRoom.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = _isRoomHide;
            }
            _isRoomHide = !_isRoomHide;
        }
    }

    void RotateAround(GameObject obj, Vector3 pivot, float angle)
    {
        Vector3 direction = obj.transform.position - pivot;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        obj.transform.position = pivot + rotation * direction;
        obj.transform.Rotate(0, angle, 0, Space.World);
    }
}
