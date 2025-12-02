using UnityEngine;

public class HideTutorial : MonoBehaviour
{
    public void HideTutorialPanel()
    {
        Destroy(GetComponentInParent<Canvas>().gameObject);
    }
}
