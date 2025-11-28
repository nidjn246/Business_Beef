using UnityEngine;

public class TrafficCone : ThrowableProp
{
    public override void Die()
    {
        AudioManager.PlaySound(SoundType.TRAFFICCONE, true, 0.6f);
        base.Die();
    }
}
