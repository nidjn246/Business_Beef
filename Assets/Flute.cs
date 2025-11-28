using UnityEngine;

public class Flute : ThrowableProp
{
    public override void Die()
    {
        AudioManager.PlaySound(SoundType.FLUTE, true, 1f);
        base.Die();
    }
}
