using System.Collections;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private bool _isMovingBack = true;

    private void Update()
    {
        if (_isMovingBack)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 2f);
        }
        else if (!_isMovingBack)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 2f);
        }
    }

    private void MoveBack()
    {
        _isMovingBack = true;
    }

    private void MoveFront()
    {
        _isMovingBack = false;
    }

    private void OnEnable()
    {
        GetMoney.OnSpawnFood += MoveBack;
        CollectMoney.OnGetMoney += MoveFront;
    }

    private void OnDisable()
    {
        GetMoney.OnSpawnFood -= MoveBack;
        CollectMoney.OnGetMoney -= MoveFront;
    }
}
