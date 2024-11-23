using System;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private GameObject smoke;
    [SerializeField] private ParticleSystem[] smokes;
    
    private void Start()
    {
        GameManager.OnBReached += OnSmokeParticle;
    }

    private void OnDestroy()
    {
        GameManager.OnBReached -= OnSmokeParticle;
    }

    private void OnSmokeParticle()
    {
        smoke.SetActive(true);
        
        foreach (var item in smokes)
        {
            item.Play();
        }
    }
}
