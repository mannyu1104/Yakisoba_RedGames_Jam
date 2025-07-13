using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _moveSpeedLeft = 0f;
    [SerializeField] private float _moveSpeedRight = 0f;
    [SerializeField] private int _moneyAmount;
    [SerializeField] private float _friction;

    public int MoneyAmount => _moneyAmount;

    private void Update()
    {
        if (transform.parent == null) return;
        if (transform.parent.rotation.z > 0f)
        {
            _moveSpeedRight = 0f; // Reset right speed when moving left
            _moveSpeedLeft = Mathf.Lerp(_moveSpeedLeft, 8f, transform.parent.rotation.z / _friction);
            transform.Translate(Vector3.left * _moveSpeedLeft * Time.deltaTime);

        }
        else if (transform.parent.rotation.z < 0f)
        {
            _moveSpeedLeft = 0f; // Reset left speed when moving right
            _moveSpeedRight = Mathf.Lerp(_moveSpeedRight, 8f, transform.parent.rotation.z / -_friction);
            transform.Translate(Vector3.right * _moveSpeedRight * Time.deltaTime);
        }
    }
}
