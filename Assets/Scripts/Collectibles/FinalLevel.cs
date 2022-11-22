using System.Collections;
using UnityEngine;

public class FinalLevel : Gem
{
    protected override IEnumerator GemCollected()
    {
        // Play particle effect
        ParticleEffectManager.instance.PlayParticleEffect(sfxGem, false);

        // Play sfx
        AudioManager.instance.PlaySound(sfxGem);

        yield return new WaitForSeconds(delay);

        // Load next level
        levelCompletion.TriggerEvent();

        yield return null;
    }
}