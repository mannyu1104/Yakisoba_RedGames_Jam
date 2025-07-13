using System;
using System.Collections;
using UnityEngine;

public class AppyGravity : MonoBehaviour
{
    private float _gravity = 9.81f;
    private bool _isTray;

    public static Action<float, float> OnFoodDestroy;

    private void FixedUpdate()
    {
        CollisionBelow();
        ApplyGravity(); 
    }


    private void ApplyGravity()
    {
        transform.Translate(Vector3.down * _gravity * Time.deltaTime);
    }

    private void CollisionBelow()
    {
        _isTray = Physics.CheckBox(transform.position, transform.localScale, Quaternion.identity, LayerMask.GetMask("Tray"));
        
        if (_isTray)
        {
            _gravity = 0f; // Stop gravity when on the tray
        }
        else
        {
            transform.SetParent(null);
            _gravity = 9.81f; // Reset gravity when not on the tray
            //StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        OnFoodDestroy?.Invoke(0f, 180f);
    }
}
