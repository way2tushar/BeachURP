using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvelopeController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CatchEnvelope();
            Destroy(this.gameObject);
        }
    }
}
