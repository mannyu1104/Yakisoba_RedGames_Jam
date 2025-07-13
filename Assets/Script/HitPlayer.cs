using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private CinemachineImpulseSource _airplaneShake;
    [SerializeField] private float _shakeForce = 0.3f;
    [SerializeField] private Transform _tray;

    private bool _isShake;
    private Vector3 _velocity;

    private void Update()
    {
        if (_isShake)
        {
            StartCoroutine(TrayShake());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isShake = true;
            PlayerShake();
        }
    }

    private void PlayerShake()
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
