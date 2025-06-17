using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mug"))
        {
            Agent agent = (Agent)FindObjectOfType(typeof(Agent));
            agent.StartAgentAnim();
        }
    }
}
