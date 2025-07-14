using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class AirplaneMovement : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private CinemachineImpulseSource _airplaneShake;
    [SerializeField] private float _shakeForce = 0.3f;
    [SerializeField] private Transform _tray;

    private float _timer;
    private float _cooldown = 20f;
    private bool _isShake;
    private Vector3 _velocity;

    private void Update()
    {

        //_timer += Time.deltaTime;

        //if (_timer > _cooldown)
        //{
        //    if (!CheckTrayGotThing()) return;
        //    _timer = 0;
        //    AirplaneShake();
        //    _isShake = true;
        //    _cooldown = Random.Range(30, 60);
        //}

        //if (_isShake)
        //{
        //    StartCoroutine(TrayShake());
        //}
    }

    private bool CheckTrayGotThing()
    {
        if (_tray.childCount == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void AirplaneShake()
    {
        float x = Random.Range(-_shakeForce, _shakeForce);
        float y = Random.Range(-_shakeForce, _shakeForce);
        _velocity = new Vector3(x, y, 0);

        _airplaneShake.GenerateImpulseWithVelocity(_velocity);
    }

    private IEnumerator TrayShake()
    {
        _tray.transform.Rotate(Vector3.forward, -50f * Time.deltaTime);
        yield return new WaitForSeconds(0.3f);
        _tray.transform.Rotate(Vector3.forward, 100f * Time.deltaTime);
        yield return new WaitForSeconds(0.3f);
        _tray.transform.Rotate(Vector3.forward, -100f * Time.deltaTime);
        yield return new WaitForSeconds(0.3f);
        _tray.transform.Rotate(Vector3.forward, 50f * Time.deltaTime);
        yield return new WaitForSeconds(0.3f);
        _isShake = false;
    }
}
