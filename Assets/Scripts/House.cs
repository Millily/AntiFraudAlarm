using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Detector _detector;

    private void OnEnable()
    {
        _detector.RogueEntered += _alarm.IncreaseVolume;
        _detector.RogueExited += _alarm.DecreaseVolume;
    }

    private void OnDisable()
    {
        _detector.RogueEntered -= _alarm.IncreaseVolume;
        _detector.RogueExited -= _alarm.DecreaseVolume;
    }
}