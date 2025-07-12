using System.Linq;
using UnityEngine;

public class Accelerometer_Control : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _shakeForce = 4f;

    private float _timer;
    private float _force;
    private float _shakeInterval = 2f;

    private void FixedUpdate()
    {

        ControlMovement();

        _timer += Time.fixedDeltaTime;

        if (_timer > _shakeInterval)
        {
            _timer = 0f;    
            RandomForce();
        }

        Shake();
    }

    private void Shake()
    {
        transform.Rotate(Vector3.forward, _force * Time.deltaTime);
    }

    private void RandomForce()
    {
        _force = Random.Range(-_shakeForce, _shakeForce);
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


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, _moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -_moveSpeed * Time.deltaTime);
        }

        //transform.Rotate(Vector3.forward, _moveSpeed * Input.acceleration.x * Time.deltaTime);
    }
}
