using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private SlideableObject _slideableObject;

    private Vector3 _velocityTilt;
    private Vector3 _lastPosition;
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _stopLerpSpeed = 3f;

    private Vector3 _smoothLerpVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_slideableObject == null) return;

        ControlMovement();
    }

    private void ControlMovement()
    {
        _velocityTilt = Input.acceleration;
        _velocityTilt = Quaternion.Euler(90, 0, 0) * _velocityTilt;

        float zVelocity;

        if (Mathf.Abs(_velocityTilt.z) >= 0.2f)
        {
            zVelocity = _velocityTilt.z * _moveSpeed;
        }
        else
        {
            zVelocity = 0f;
        }

        _smoothLerpVelocity.z = Mathf.Lerp(_smoothLerpVelocity.z, zVelocity, Time.deltaTime * _stopLerpSpeed);

        Vector3 trayDelta = new Vector3(0f, 0f, _smoothLerpVelocity.z * Time.fixedDeltaTime);
        Vector3 newPosition = _rb.position + trayDelta;

        if (_slideableObject != null)
        {
            Vector3 adjusted = _slideableObject.AdjustVelocityToSlope(_smoothLerpVelocity);
            _slideableObject.OnPlayerMove(adjusted);
        }

        _lastPosition = newPosition;

        _rb.MovePosition(newPosition);

    }

    public void GetCurrentFood(SlideableObject sObject)
    {
        _slideableObject = sObject;
    }
}
