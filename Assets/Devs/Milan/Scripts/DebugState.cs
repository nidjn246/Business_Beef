using TMPro;
using UnityEngine;

public class DebugState : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stateText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stateText.text = "State: " + PlayerState.Instance.currentState.ToString();
    }
}
