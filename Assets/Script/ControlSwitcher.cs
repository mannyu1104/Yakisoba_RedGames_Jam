using System;
using UnityEngine;

public class ControlSwitcher : MonoBehaviour
{
    [SerializeField] private Accelerometer_Control _accelerometerControl; 
    [SerializeField] private PlayerMovement _accelerometerMove; 
    [SerializeField] private ButtonInput_Balance _buttonBalanceControl;       
    [SerializeField] private ButtonInput_Movement _buttonMove;

    public static Action<Enum_ControlType> OnControlTypeChanged;

    private void Awake()
    {
        if (_accelerometerControl != null || _buttonBalanceControl != null || _accelerometerMove != null || _buttonMove != null)
        {
            GameSettingsManager.LoadControlType(); // Load saved setting
            SwitchControl(GameSettingsManager.CurrentControlType);
        }
        
    }

    public void SwitchControl(Enum_ControlType type)
    {
        _accelerometerControl.enabled = (type == Enum_ControlType.WithAccelerometer);
        _accelerometerMove.enabled = (type == Enum_ControlType.WithAccelerometer);

        _buttonBalanceControl.enabled = (type == Enum_ControlType.WithoutAccelerometer);
        _buttonMove.enabled = (type == Enum_ControlType.WithoutAccelerometer);

        
    }

    public void SetWithAccelerometer()
    {
        GameSettingsManager.SetControlType(Enum_ControlType.WithAccelerometer);


        if (_accelerometerControl != null || _buttonBalanceControl != null || _accelerometerMove != null || _buttonMove != null)
        {
            OnControlTypeChanged?.Invoke(Enum_ControlType.WithAccelerometer);

        }


    }

    public void SetWithoutAccelerometer()
    {
        GameSettingsManager.SetControlType(Enum_ControlType.WithoutAccelerometer);


        if (_accelerometerControl != null || _buttonBalanceControl != null || _accelerometerMove != null || _buttonMove != null)
        {
            OnControlTypeChanged?.Invoke(Enum_ControlType.WithoutAccelerometer);

        }

    }

    private void OnEnable()
    {
        ControlSwitcher.OnControlTypeChanged += SwitchControl;
    }

    private void OnDisable()
    {
        ControlSwitcher.OnControlTypeChanged -= SwitchControl;
    }
}
