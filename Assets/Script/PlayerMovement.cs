using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _velocityTilt;
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _stopLerpSpeed = 3f;

    private Vector3 _smoothLerpVelocity;

    private Vector3 _calibrationOffset;


    private void Start()
    {
        CalibrateNeutralPosition();
    }

    private void FixedUpdate()
    {
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

        transform.Translate(trayDelta);
    }

    public void CalibrateNeutralPosition()
    {
        // Store current accelerometer reading as the "neutral" position
        _calibrationOffset = Input.acceleration;
        Debug.Log("Calibrated neutral position: " + _calibrationOffset);
    }
}
