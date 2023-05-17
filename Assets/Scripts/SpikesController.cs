using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    public GlitchEffect glitchEffect;
    public float duration;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MovementController>().MovePlayerAtStartOfLevel();
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
