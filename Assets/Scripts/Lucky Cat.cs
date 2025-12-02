using JetBrains.Annotations;
using UnityEngine;

public class LuckyCat : ThrowableProp
{
    override public void Die()
    {
        AudioManager.PlaySound(SoundType.CATMEOW, true, 0.6f);
        base.Die();

        
    }
}
