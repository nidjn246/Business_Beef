using UnityEngine;

public class WoodCrate : ThrowableProp
{
    public override void Die()
    {
        SpawnParticles();
        base.Die();
        AudioManager.PlaySound(SoundType.CRATEBREAK, true, 0.6f);
    }

}
