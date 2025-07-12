using System;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private float _timer;
    private bool _isRotating;
    private float _duration = 3f;

    public static Action<bool> OnStart;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _duration)
        {
            _timer = 0f;
            _isRotating = false;
            OnStart?.Invoke(true);

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                _timer = 0f;
                _isRotating = true;

            }
        }

        if (_isRotating)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 60f, Space.Self); 
        }

    }


}
