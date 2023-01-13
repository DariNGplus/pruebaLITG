using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleRadius : MonoBehaviour
{
    public BlackHoleBehaviour behaviour;
    
    void Start()
    {
        behaviour = GetComponentInParent<BlackHoleBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("HoleOrigin") & other.attachedRigidbody != null) {
            behaviour.attractees.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("HoleOrigin") & other.attachedRigidbody != null)
        {
            behaviour.attractees.Remove(other.attachedRigidbody);
        }
    }

}
