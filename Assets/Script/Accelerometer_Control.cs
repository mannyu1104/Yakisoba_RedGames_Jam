using System.Linq;
using UnityEngine;

public class Accelerometer_Control : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    private Vector3 _calibrationOffset;

    private void Start()
    {
        CalibrateNeutralPosition();
    }

    private void FixedUpdate()
    {
        ControlBalance();

    }

    private void ControlBalance()
    {

        transform.Rotate(Vector3.forward, -_moveSpeed * Input.acceleration.x);
    }

    public void CalibrateNeutralPosition()
    {
        // Store current accelerometer reading as the "neutral" position
        _calibrationOffset = Input.acceleration;
        Debug.Log("Calibrated neutral position: " + _calibrationOffset);
    }
}
