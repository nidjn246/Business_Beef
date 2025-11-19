using System.Collections.Generic;
using UnityEngine;

public class PlayerColors : MonoBehaviour
{
    [SerializeField] private List<GameObject> normalSkins;
    [SerializeField] private List<GameObject> bossSkins;
    [SerializeField] private GameObject whiteSkin;

    public void ChangeColor(string team, int boss)
    {
        switch (team)
        {
            case "orange":
                if (boss == 1)
                {
                    ResetSkins();
                    bossSkins[1].gameObject.SetActive(true);
                }
                else
                {
                    ResetSkins();
                    normalSkins[1].gameObject.SetActive(true);
                }
                break;
            case "blue":
                if (boss == 1)
                {
                    ResetSkins();
                    bossSkins[0].gameObject.SetActive(true);
                }
                else
                {
                    ResetSkins();
                    normalSkins[0].gameObject.SetActive(true);
                }
                break;
            case "white":
                ResetSkins();
                whiteSkin.SetActive(true);
                break;
        }
    }

    private void ResetSkins()
    {
        for (int i = 0; i < normalSkins.Count; i++)
        {
            normalSkins[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < bossSkins.Count; i++)
        {
            bossSkins[i].gameObject.SetActive(false);
        }
        whiteSkin.SetActive(false);
    }

}
