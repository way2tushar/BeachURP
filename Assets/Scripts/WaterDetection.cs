using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetWaterTouch(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetWaterTouch(false);
        }
    }
}
