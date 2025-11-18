using TMPro;
using UnityEngine;

public class AmountOfPlayersUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI blue;
    [SerializeField] private TextMeshProUGUI orange;



    // Update is called once per frame
    void Update()
    {
        blue.text = TeamManager.instance.blueTeamMembers.Count + "/2";
        orange.text = TeamManager.instance.orangeTeamMembers.Count + "/2";
    }
}
