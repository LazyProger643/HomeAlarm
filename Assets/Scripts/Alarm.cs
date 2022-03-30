using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Alarm : MonoBehaviour
{
    [SerializeField, Range(0, 0.5f)] private float _minVolume = 0;
    [SerializeField, Range(0.5f, 1)] private float _maxVolume = 1;
    [SerializeField, Range(0.25f, 4)] private float _volumeChangeSpeed = 1;

    private AudioSource _sound;
    private float _targetVolume;

    public float Volume => Mathf.InverseLerp(_minVolume, _maxVolume, _sound.volume);

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = _minVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetVolume = _maxVolume;

        _sound.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _targetVolume = _minVolume;
    }

    private void Update()
    {
        if (_sound.isPlaying)
        {
            if (_sound.volume != _targetVolume)
            {
                _sound.volume = Mathf.MoveTowards(_sound.volume, _targetVolume, _volumeChangeSpeed * Time.deltaTime);
            }
            else if (_sound.volume == _minVolume)
            {
                _sound.Stop();
            }
        }
    }
}
