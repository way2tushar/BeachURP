using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(GameManager.Instance.GetEnvelopeState()){
                animator.SetTrigger("Open");
                GameManager.Instance.ChestOpened();
            }
            
        }
    }
}
