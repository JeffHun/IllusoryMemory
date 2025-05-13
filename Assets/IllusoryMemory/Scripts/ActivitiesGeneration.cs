using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesGeneration : MonoBehaviour
{
    [SerializeField] GameObject _crumbledPaperBall, _lamp, _PC, _bottle, _phoneNumber, _phone, _story, _compositePortrait, _postit, _map, _ruler, _fan, _sunflower, _USBKey, _calculator, _tuto, _agent;

    List<GameObject> _activities = new List<GameObject>();

    public void SpawnActivity(Transform currentRoom)
    {
        for (int i = 0; i < _activities.Count; i++)
        {
            Destroy(_activities[i]);
        }
        _activities.Clear();

        for (int i = 0; i < currentRoom.childCount; i++)
        {
            switch (currentRoom.GetChild(i).name)
            {
                case "CrumbledPaperBallSpawnPoint":
                    _activities.Add(Instantiate(_crumbledPaperBall, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "LampSpawnPoint":
                    _activities.Add(Instantiate(_lamp, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "PCSpawnPoint":
                    _activities.Add(Instantiate(_PC, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "BottleSpawnPoint":
                    _activities.Add(Instantiate(_bottle, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "PhoneNumberSpawnPoint":
                    _activities.Add(Instantiate(_phoneNumber, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "PhoneSpawnPoint":
                    _activities.Add(Instantiate(_phone, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "StorySpawnPoint":
                    _activities.Add(Instantiate(_story, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "CompositePortraitSpawnPoint":
                    _activities.Add(Instantiate(_compositePortrait, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "PostitSpawnPoint":
                    _activities.Add(Instantiate(_postit, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "MapSpawnPoint":
                    _activities.Add(Instantiate(_map, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "RulerSpawnPoint":
                    _activities.Add(Instantiate(_ruler, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "FanSpawnPoint":
                    _activities.Add(Instantiate(_fan, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "SunflowerSpawnPoint":
                    _activities.Add(Instantiate(_sunflower, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "CalculatorSpawnPoint":
                    _activities.Add(Instantiate(_calculator, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "USBKeySpawnPoint":
                    _activities.Add(Instantiate(_USBKey, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "TutoSpawnPoint":
                    _activities.Add(Instantiate(_tuto, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
                case "AgentSpawnPoint":
                    _activities.Add(Instantiate(_agent, currentRoom.GetChild(i).position, currentRoom.GetChild(i).rotation));
                    break;
            }
        }
    }
}