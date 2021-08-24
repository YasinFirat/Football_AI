using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackDedector : MonoBehaviour
{
    public string tag="Attack";
    public UnityEvent onEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            onEnter?.Invoke();
        }
    }
}
