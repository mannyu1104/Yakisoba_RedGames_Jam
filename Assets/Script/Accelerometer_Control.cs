using System.Linq;
using UnityEngine;

public class Accelerometer_Control : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 2f;
    //[SerializeField] private float _stopLerpSpeed = 3f;

    private void FixedUpdate()
    {
        ControlMovement();

    }

    // Update is called once per frame
    private void Update()
    {
        ControlBalance();

    }

    private void LateUpdate()
    {
        TrayVelocity = (transform.position - _lastPosition) / Time.deltaTime;
        _lastPosition = transform.position;
    }

    private void ControlBalance()
    {
        //_rotationTilt = Input.acceleration.x;
        //float zAngle = _rotationTilt * 180;

        //transform.rotation = Quaternion.Euler(0, 0, -zAngle);
    }

    private void ControlMovement()
    {
        //_velocityTilt = Input.acceleration;
        //_velocityTilt = Quaternion.Euler(90, 0, 0) * _velocityTilt;

        //float zVelocity;

        //if (Mathf.Abs(_velocityTilt.z) >= 0.2f)
        //{
        //    zVelocity = _velocityTilt.z * _moveSpeed;
        //}
        //else
        //{
        //    zVelocity = 0f;
        //}

        //_smoothLerpVelocity.z = Mathf.Lerp(_smoothLerpVelocity.z, zVelocity, Time.deltaTime * _stopLerpSpeed);

        //Vector3 trayDelta = new Vector3(0f, 0f, _smoothLerpVelocity.z * Time.fixedDeltaTime);
        //Vector3 newPosition = _rb.position + trayDelta;

        //TrayVelocity = (newPosition - _lastPosition) / Time.fixedDeltaTime;
        //_lastPosition = newPosition;

        //_rb.MovePosition(newPosition);


        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(Vector3.forward, _moveSpeed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(Vector3.forward, -_moveSpeed * Time.deltaTime);
        //}

        transform.Rotate(Vector3.forward, _moveSpeed * Input.acceleration.x * Time.deltaTime);
    }
}
