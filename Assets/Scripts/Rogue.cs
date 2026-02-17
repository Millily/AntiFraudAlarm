using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Rogue : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    void Update()
    {
        _mover.Move();
    }
}