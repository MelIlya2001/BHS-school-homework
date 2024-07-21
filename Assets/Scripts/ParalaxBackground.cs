using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField, Range(0, 1)] private float _horisontalMovementMultiplier;
    [SerializeField, Range(0, 1)] private float _verticalMovementMultiplier;

    private Vector3 _targetPosition => _target.position;
    private Vector3 _lastTargetPosition;


    // Start is called before the first frame update
    private void Start()
    {
        _lastTargetPosition = _targetPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 delta = _targetPosition - _lastTargetPosition;
        delta *= new Vector2(_horisontalMovementMultiplier, _verticalMovementMultiplier); 
        transform.position += delta;
        _lastTargetPosition = _targetPosition;
    }
}
