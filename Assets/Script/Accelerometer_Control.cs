using System.Linq;
using UnityEngine;

public class Accelerometer_Control : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;

    private void FixedUpdate()
    {
        ControlBalance();

    }

    private void ControlBalance()
    {

        transform.Rotate(Vector3.forward, -_moveSpeed * Input.acceleration.x);
    }
}
