using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsVisibility : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private PlayerMovement playerMovement;
    private PlayerJump playerJump;
    private GameObject lastSelectedObject;
    private void Start()
    {

    }
    public void OnSettings()
    {

        EventSystem eventSystem = FindFirstObjectByType<EventSystem>();
        lastSelectedObject = eventSystem.currentSelectedGameObject;
        canvas.SetActive(!canvas.activeSelf);
        Time.timeScale = canvas.activeSelf ? 0f : 1f;
        if (canvas.activeSelf && lastSelectedObject != null)
        {
            eventSystem.SetSelectedGameObject(lastSelectedObject);
        }
        else if (canvas.activeSelf && lastSelectedObject == null)
        {
            lastSelectedObject = FindFirstObjectByType<TMP_Dropdown>().gameObject;
            eventSystem.SetSelectedGameObject(lastSelectedObject);
        }

    }
}
