using UnityEngine;

public class ValuableProp : MonoBehaviour
{
    [SerializeField] private int value = 500;
    private bool isSlowing = false;
    private PlayerMovement pm;
    private float originalSpeed;
    private GameObject player;

    private void Awake()
    {

    }
    private void Update()
    {
        if (transform.parent != null && transform.parent.name == "Inventory")
        {
            if (!isSlowing)
                SlowPlayer();
            player = transform.parent.parent.gameObject;
        }
        else
        {
            if (isSlowing)
                RestoreSpeed();
            player = null;
        }
    }

    public void SlowPlayer()
    {
        pm = transform.parent.GetComponentInParent<PlayerMovement>();
        if (pm == null) return;

        originalSpeed = pm.speed;
        pm.speed *= 0.5f;  // halve speed ONCE
        isSlowing = true;
    }

    public void RestoreSpeed()
    {
        if (pm != null)
        {
            pm.speed = originalSpeed; // restore original speed
        }
        isSlowing = false;
    }

    public void OnSell()
    {
        if (player.layer == 9)
        {
            GameScore.instance.AddScore(GameScore.TeamNumber.Team1, value);
        }

        if (player.layer == 10)
        {
            GameScore.instance.AddScore(GameScore.TeamNumber.Team2, value);
        }
    }
}
