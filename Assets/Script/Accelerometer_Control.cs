using UnityEngine;

public class Accelerometer_Control : MonoBehaviour
{
    private Rigidbody _rb;

    private float _rotationTilt;
    private Vector3 _velocityTilt;
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _stopLerpSpeed = 3f;

    private Vector3 _smoothLerpVelocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        ControlBalance();
        ControlMovement();

    }

    private void ControlBalance()
    {
        _rotationTilt = Input.acceleration.x;
        float zAngle = _rotationTilt * 180;

        transform.rotation = Quaternion.Euler(0, 0, -zAngle);
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

        Vector3 newPosition = _rb.position + new Vector3(0f, 0f, _smoothLerpVelocity.z * Time.deltaTime);

        _rb.MovePosition(newPosition);

    }
}
