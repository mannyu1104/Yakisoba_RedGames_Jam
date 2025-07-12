using System.Linq;
using UnityEngine;

public class Accelerometer_Control : MonoBehaviour
{

    private float _rotationTilt;

    private Vector3 _smoothLerpVelocity;

    private Vector3 _lastPosition;
    public Vector3 TrayVelocity { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _lastPosition = transform.position;
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
        _rotationTilt = Input.acceleration.x;
        float zAngle = _rotationTilt * 180;

        transform.rotation = Quaternion.Euler(0, 0, -zAngle);
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
