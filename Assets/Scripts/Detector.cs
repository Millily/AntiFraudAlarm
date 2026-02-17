using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action RogueEntered;
    public event Action RogueExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Rogue>(out _))
        {
            RogueEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Rogue>(out _))
        {
            RogueExited?.Invoke();
        }
    }
}