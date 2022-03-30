using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public float AlarmVolume => _alarm.Volume;
}
