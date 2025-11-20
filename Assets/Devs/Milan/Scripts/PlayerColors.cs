using System.Collections.Generic;
using UnityEngine;

public class PlayerColors : MonoBehaviour
{
    [SerializeField] private List<GameObject> normalSkins;
    [SerializeField] private List<GameObject> bossSkins;
    [SerializeField] private GameObject whiteSkin;

    public bool UpdateColor(bool alreadyBoss)
    {
        if (TeamManager.instance.blueTeamMembers.Contains(gameObject))
        {
            ResetSkins();
            if (alreadyBoss)
            {
                normalSkins[0].SetActive(true);
                return false;
            }
            else
            {
                bossSkins[0].SetActive(true);
                return true;
            }
        }
        else if (TeamManager.instance.orangeTeamMembers.Contains(gameObject))
        {
            ResetSkins();
            if (alreadyBoss)
            {
                normalSkins[1].SetActive(true);
                return false;
            }
            else
            {
                bossSkins[1].SetActive(true);
                return true;
            }
        }
        else
        {
            ResetSkins();
            whiteSkin.SetActive(true);
            return false;
        }
        return true;
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
