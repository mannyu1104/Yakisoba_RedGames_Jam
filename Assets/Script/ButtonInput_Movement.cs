using UnityEngine;

public class ButtonInput_Movement : MonoBehaviour
{
    [SerializeField] private float _verticleMoveSpeed = 8f;
    [SerializeField] private float _horizontalMoveSpeed = 0.2f;
    [SerializeField] private float _stopLerpSpeed = 3f;

    private Vector3 _smoothLerpVelocity;

    private int _verticleInput = 0;
    private int _horizontalInput = 0;

    private void FixedUpdate()
    {
        ControlMovement();
    }

    private void ControlMovement()
    {

        float zVelocity = _verticleInput * _verticleMoveSpeed;

        _smoothLerpVelocity.z = Mathf.Lerp(_smoothLerpVelocity.z, zVelocity, Time.deltaTime * _stopLerpSpeed);

        float xVelocity = _horizontalInput * _horizontalMoveSpeed;

        _smoothLerpVelocity.x = Mathf.Lerp(_smoothLerpVelocity.x, xVelocity, Time.deltaTime * _stopLerpSpeed);

        Vector3 moveOn = new Vector3(_smoothLerpVelocity.x, 0f, _smoothLerpVelocity.z * Time.fixedDeltaTime);

        transform.Translate(moveOn);
    }


    public void ReadHorizontalInput(int value)
    {
        _horizontalInput = value;
    }

    public void ReadVerticleInput(int value)
    {
        _verticleInput = value;
    }
}
