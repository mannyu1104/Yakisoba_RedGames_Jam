using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _velocityTilt;
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _sideMoveSpeed = 3f;
    [SerializeField] private float _stopLerpSpeed = 3f;
    [SerializeField] private float _smoothingSpeed = 5f;

    private Vector3 _smoothLerpVelocity;
    private Vector3 _smoothedAcceleration;
    private Vector3 _calibrationOffset;

    private int _sideInput = 0;


    private void Start()
    {
        CalibrateNeutralPosition();
    }

    private void Update()
    {
        SmoothAccelerometerInput();
    }

    private void FixedUpdate()
    {
        ControlMovement();
    }

    private void ControlMovement()
    {
        // Apply calibration offset to accelerometer input
        Vector3 calibratedAcceleration = _smoothedAcceleration - _calibrationOffset;

        _velocityTilt = calibratedAcceleration;
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

        float xVelocity = _sideInput * _sideMoveSpeed;

        _smoothLerpVelocity.x = Mathf.Lerp(_smoothLerpVelocity.x, xVelocity, Time.deltaTime * _stopLerpSpeed);

        Vector3 moveOn = new Vector3(_smoothLerpVelocity.x, 0f, _smoothLerpVelocity.z * Time.fixedDeltaTime);

        transform.Translate(moveOn);
    }

    private void SmoothAccelerometerInput()
    {
        _smoothedAcceleration = Vector3.Lerp(_smoothedAcceleration, Input.acceleration, Time.deltaTime * _smoothingSpeed);
    }

    public void CalibrateNeutralPosition()
    {
        _calibrationOffset = Input.acceleration;
        Debug.Log("Calibrated neutral position: " + _calibrationOffset);
    }

    public void SetSideInput(int value)
    {
        _sideInput = value;
    }
}
