using System.Linq;
using UnityEngine;

public class Accelerometer_Control : MonoBehaviour
{
    private Rigidbody _rb;

    private float _rotationTilt;
    private Vector3 _velocityTilt;
    private Vector3 _lastPosition;
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _stopLerpSpeed = 3f;

    private Vector3 _smoothLerpVelocity;

    public Vector3 TrayVelocity { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ControlMovement();

    }

    // Update is called once per frame
    private void Update()
    {
        ControlBalance();

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

        Vector3 trayDelta = new Vector3(0f, 0f, _smoothLerpVelocity.z * Time.fixedDeltaTime);
        Vector3 newPosition = _rb.position + trayDelta;

        TrayVelocity = (newPosition - _lastPosition) / Time.fixedDeltaTime;
        _lastPosition = newPosition;

        _rb.MovePosition(newPosition);

    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("SlideableObjects"))
        {

            Vector3 adjustedVelocity = collision.GetComponent<SlideableObject>().AdjustVelocityToSlope(_smoothLerpVelocity);
            collision.GetComponent<SlideableObject>().OnPlayerMove(adjustedVelocity);

        }
    }

}
