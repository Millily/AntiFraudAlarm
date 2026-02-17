using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private Detector _detector;
    private AudioSource _audioSource;
    private Coroutine _coroutine;
    private int _maxVolume = 1;
    private int _minVolume = 0;

    private void OnEnable()
    {
        _detector.RogueEntered += DecreaseVolume;
        _detector.RogueExited += IncreaseVolume;
    }

    private void OnDisable()
    {
        _detector.RogueEntered -= DecreaseVolume;
        _detector.RogueExited -= IncreaseVolume;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.playOnAwake = false;
    }

    private void DecreaseVolume()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    private void IncreaseVolume()
    {
        _coroutine = StartCoroutine(ChangeVolume(_minVolume));

        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }

    private IEnumerator ChangeVolume(int target)
    {
        float speed = 0.5f;

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, speed * Time.deltaTime);
            yield return null;
        }

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}