using System;
using System.Collections;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Accelerometer_Control _accelerometer_Control;
    
    private float _timer;
    private bool _isRotating;
    private float _duration = 3f;

    public static Action<bool> OnStart;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _accelerometer_Control = GetComponentInChildren<Accelerometer_Control>();
        _playerMovement.enabled = false;
        _accelerometer_Control.enabled = false;

        StartCoroutine(StartRotation());
    }

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
            StartCoroutine(StartRotation());
        }

    }

    private IEnumerator StartRotation()
    {
        yield return new WaitForSeconds(1f);

        float duration = 6f;
        float elapsed = 0f;

        Quaternion startRotation = Quaternion.Euler(0f, 180f, 0f);
        Quaternion endRotation = Quaternion.Euler(0f, 0f, 0f);

        while (transform.rotation.y != 0)
        {
            float t = elapsed / duration;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        _isRotating = false;
        _playerMovement.enabled = true;
        _accelerometer_Control.enabled = true;

    }


}
