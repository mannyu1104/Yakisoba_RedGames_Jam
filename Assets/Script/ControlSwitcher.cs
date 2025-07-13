using System;
using UnityEngine;

public class ControlSwitcher : MonoBehaviour
{
    [SerializeField] private MonoBehaviour accelerometerControl; 
    [SerializeField] private MonoBehaviour accelerometerMove; 
    [SerializeField] private MonoBehaviour buttonBalanceControl;       
    [SerializeField] private MonoBehaviour buttonMove;

    public static Action<Enum_ControlType> OnControlTypeChanged;

    private void Awake()
    {
        GameSettingsManager.LoadControlType(); // Load saved setting
        SwitchControl(GameSettingsManager.CurrentControlType);
    }

    public void SwitchControl(Enum_ControlType type)
    {
        accelerometerControl.enabled = (type == Enum_ControlType.WithAccelerometer);
        accelerometerMove.enabled = (type == Enum_ControlType.WithAccelerometer);

        buttonBalanceControl.enabled = (type == Enum_ControlType.WithoutAccelerometer);
        buttonMove.enabled = (type == Enum_ControlType.WithoutAccelerometer);

        
    }

    public void ToggleInput() // Can be called from a UI button
    {
        Enum_ControlType controlType;

        if (GameSettingsManager.CurrentControlType == Enum_ControlType.WithAccelerometer)
        {
            controlType = Enum_ControlType.WithoutAccelerometer;
        }
        else
        {
            controlType = Enum_ControlType.WithAccelerometer;
        }

        GameSettingsManager.SetControlType(controlType);
        OnControlTypeChanged?.Invoke(controlType);
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
