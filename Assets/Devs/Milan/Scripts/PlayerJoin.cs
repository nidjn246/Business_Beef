using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup targetGroup;
    public void OnJoin(PlayerInput playerInput)
    {

        switch (playerInput.playerIndex)
        {
            case 0:
                playerInput.gameObject.name = "Player 1";
                targetGroup.AddMember(playerInput.transform, 1f, 2f);
                break;
            case 1:
                playerInput.gameObject.name = "Player 2";
                targetGroup.AddMember(playerInput.transform, 1f, 2f);
                break;
            case 2:
                playerInput.gameObject.name = "Player 3";
                targetGroup.AddMember(playerInput.transform, 1f, 2f);
                break;
            case 3:
                playerInput.gameObject.name = "Player 4";
                targetGroup.AddMember(playerInput.transform, 1f, 2f);
                break;
        }
    }

}
