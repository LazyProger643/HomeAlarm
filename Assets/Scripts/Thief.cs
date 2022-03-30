using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Environment _environment;
    [SerializeField] private Point _targetPoint;
    [SerializeField] private Point _escapePoint;
    [SerializeField] private float _walkSpeed = 1;
    [SerializeField] private float _runSpeed = 2;
    [SerializeField, Range(0.1f, 0.9f)] private float _alarmVolumeToEscape = 0.5f;

    private Vector3 _targetPosition;
    private float _moveSpeed;

    private void Start()
    {
        _targetPosition = _targetPoint.transform.position;
        _moveSpeed = _walkSpeed;
    }

    private void Update()
    {
        if (_environment.AlarmVolume >= _alarmVolumeToEscape)
        {
            _targetPosition = _escapePoint.transform.position;
            _moveSpeed = _runSpeed;
        }
        
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.MoveTowards(newPosition.x, _targetPosition.x, _moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
