using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchEffectTrigger : MonoBehaviour
{
    public GlitchEffect glitchEffect;
    public float duration;
    public bool alreadyActivated = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !alreadyActivated)
        {
            alreadyActivated = true;
            StartCoroutine(GlitchEffectDuration(duration));
        }
    }

    private IEnumerator GlitchEffectDuration(float duration)
    {
        glitchEffect.enabled = true;
        yield return new WaitForSeconds(duration);
        glitchEffect.enabled = false;
    }
}
