using Unity.Cinemachine;
using UnityEngine;

public class PlayerBumb : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private CinemachineImpulseSource _cinemachineCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            _cinemachineCamera.GenerateImpulse();
            transform.Rotate(Vector3.forward, 3f);
        }
        
    }
}
