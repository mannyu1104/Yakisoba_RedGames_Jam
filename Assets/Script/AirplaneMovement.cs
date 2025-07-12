using UnityEngine;

public class AirplaneMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _duration = 2f;

    private float _timer;
    private bool _isMovingDown;
    private bool _isMovingUp;
    private float _speed = 5f;

    private void Update()
    {
        _timer += Time.deltaTime;
        
        

        if (_timer > _duration)
        {
            _timer = 0f; 
            _isMovingDown = false;
            _isMovingUp = false; 

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _timer = 0f;
                _isMovingDown = true;

            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _timer = 0f;
                _isMovingUp = true;
            }
        }

        if (_isMovingDown)
        {
            PlaneMoveDown();
        }
        if (_isMovingUp)
        {
            PlaneMoveUp();
        }

    }

    private void PlaneMoveUp()
    {
        _speed = 5f; 
        transform.Rotate(Vector3.right * Time.deltaTime * _speed);
    }

    private void PlaneMoveDown()
    {
        _speed = 5f;
        transform.Rotate(Vector3.left * Time.deltaTime * _speed);
    }
}
