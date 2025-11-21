using TMPro;
using UnityEngine;

public class AmountOfPlayersUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI blue;
    [SerializeField] private TextMeshProUGUI orange;



    void Update()
    {
        blue.text = TeamManager.instance.blueTeamMembers.Count + "/2";
        orange.text = TeamManager.instance.orangeTeamMembers.Count + "/2";
    }
}
