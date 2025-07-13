using UnityEngine;

public static class GameSettingsManager
{
    public static Enum_ControlType CurrentControlType { get; private set; } = Enum_ControlType.WithAccelerometer;

    public static void SetControlType(Enum_ControlType controlType)
    {
        CurrentControlType = controlType;
        PlayerPrefs.SetInt("ControlType", (int)controlType); // Save it
    }

    public static void LoadControlType()
    {
        if (PlayerPrefs.HasKey("ControlType"))
        {
            CurrentControlType = (Enum_ControlType)PlayerPrefs.GetInt("ControlType");
        }
    }
}
