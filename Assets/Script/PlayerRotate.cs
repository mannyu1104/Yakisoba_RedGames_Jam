using System;
using System.Collections;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private Accelerometer_Control _accelerometerControl;
    private PlayerMovement _accelerometerMove;
    private ButtonInput_Balance _buttonBalanceControl;
    private ButtonInput_Movement _buttonMove;

    private bool _isRotating;
    private Transform _tray;

    private void Start()
    {
        _accelerometerMove = GetComponent<PlayerMovement>();
        _buttonMove = GetComponent<ButtonInput_Movement>();
        _accelerometerControl = GetComponentInChildren<Accelerometer_Control>();
        _buttonBalanceControl = GetComponentInChildren<ButtonInput_Balance>();
        _tray = GameObject.FindGameObjectWithTag("Tray").transform;
        _accelerometerMove.enabled = false;
        _accelerometerControl.enabled = false;
        _buttonBalanceControl.enabled = false;
        _buttonMove.enabled = false;


        StartCoroutine(StartRotation(180f, 0f));
    }

    private void Rotate(float angle1, float angle2)
    {
        _accelerometerMove.enabled = false;
        _accelerometerControl.enabled = false;
        _buttonBalanceControl.enabled = false;
        _buttonMove.enabled = false;

        StartCoroutine(StartRotation(angle1, angle2));
    }


    private IEnumerator StartRotation(float angle1, float angle2)
    {
        yield return new WaitForSeconds(1f);

        float duration = 2f;
        float elapsed = 0f;

        Quaternion startRotation = Quaternion.Euler(0f, angle1, 0f);
        Quaternion endRotation = Quaternion.Euler(0f, angle2, 0f);

        while (transform.rotation.y != angle2 && elapsed <= duration)
        {
            float t = elapsed / duration;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            elapsed += Time.deltaTime;
            Debug.Log("elapsed: " + elapsed);
            yield return null;
        }

        if (GameSettingsManager.GetControlType() == Enum_ControlType.WithAccelerometer)
        {
            _accelerometerMove.enabled = true;
            _accelerometerControl.enabled = true;
        }
        else
        {
            _buttonBalanceControl.enabled = true;
            _buttonMove.enabled = true;
        }
        _tray.rotation = Quaternion.Euler(0, 0, 0);
       
    }

    private void OnEnable()
    {
        AppyGravity.OnFoodDestroy += Rotate;
        CollectMoney.OnGetReward += Rotate;
        GetMoney.OnComplete += Rotate;
    }

    private void OnDisable()
    {
        AppyGravity.OnFoodDestroy -= Rotate;
        CollectMoney.OnGetReward -= Rotate;
        GetMoney.OnComplete -= Rotate;
    }


}
