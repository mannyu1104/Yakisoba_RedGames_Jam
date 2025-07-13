using UnityEngine;

public class Accelerometer_Control : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _shakeForce = 4f;

    private float _timer;
    private float _force;
    private float _shakeInterval = 2f;

    private Vector3 _calibrationOffset;

    private void FixedUpdate()
    {

        ControlBalance();

        _timer += Time.fixedDeltaTime;

        if (_timer > _shakeInterval)
        {
            _timer = 0f;    
            RandomForce();
        }

        //Shake();

    }

    private void Shake()
    {
        transform.Rotate(Vector3.forward, _force * Time.deltaTime);
    }

    private void RandomForce()
    {
        _force = Random.Range(-_shakeForce, _shakeForce);
    }

    private void ControlBalance()
    {
        transform.Rotate(Vector3.forward, _moveSpeed * Input.acceleration.x);
    }

    public void CalibrateNeutralPosition()
    {
        // Store current accelerometer reading as the "neutral" position
        _calibrationOffset = Input.acceleration;
        Debug.Log("Calibrated neutral position: " + _calibrationOffset);
    }
}
