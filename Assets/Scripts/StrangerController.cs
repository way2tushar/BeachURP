using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.Instance.ShowConversation();
        }
    }
}
