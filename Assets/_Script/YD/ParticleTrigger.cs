using System;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.isDead == false)
                player.Dead();
        }    
    }
}