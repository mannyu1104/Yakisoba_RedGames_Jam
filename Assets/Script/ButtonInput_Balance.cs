using UnityEngine;

public class ButtonInput_Balance : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _shakeForce = 4f;
    private int _balanceDirection;
    private float _currentDirection;
    private float _lerpSpeed = 5f;

    private float _timer;
    private float _force;
    private float _shakeInterval = 2f;

    private void FixedUpdate()
    {
        SmoothDirection();
        ControlBalance();

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

    private void ControlBalance()
    {
        transform.Rotate(Vector3.forward, _moveSpeed * _currentDirection * Time.fixedDeltaTime);
    }

    private void SmoothDirection()
    {
        _currentDirection = Mathf.Lerp(_currentDirection, _balanceDirection, Time.fixedDeltaTime * _lerpSpeed);
    }

    public void ReadDirection(int value)
    {
        _balanceDirection = value;
    }
}
