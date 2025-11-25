using UnityEngine;

public class PlayerSettingsSwitch : MonoBehaviour
{
    private SettingsVisibility settingsVisibility;
    void Start()
    {
        settingsVisibility = FindFirstObjectByType<SettingsVisibility>();
    }

    // Update is called once per frame
    public void Switch()
    {
        settingsVisibility.OnSettings();
    }
}
