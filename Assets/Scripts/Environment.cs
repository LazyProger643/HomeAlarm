using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public float AlarmVolume => _alarm.Volume;
}
