using Unity.Cinemachine;
using UnityEngine;

public class PlayerBumb : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private CinemachineImpulseSource _cinemachineCamera;

    private float _direction;

    private int _dir;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            _cinemachineCamera.GenerateImpulse();

            _dir = Random.Range(1, 3);

            if (_dir == 1)
            {
                _direction = 1f; // Right
            }
            else if (_dir == 2)
            {
                _direction = -1f; // Left
            }

            Debug.Log("Bumb: " + _direction);
            transform.Rotate(Vector3.forward, 10f * _direction, Space.Self);
        }
        
    }
}
