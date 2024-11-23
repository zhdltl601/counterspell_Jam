using System;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private GameObject smoke;
    [SerializeField] private ParticleSystem[] smokes;
    [SerializeField] private GameObject _collider;
    
    private void Start()
    {
        GameManager.OnBReached += OnSmokeParticle;
        GameManager.OnBReached += OnCollider;
    }

    private void OnDestroy()
    {
        GameManager.OnBReached -= OnSmokeParticle;
        GameManager.OnBReached -= OnCollider;
    }

    private void OnSmokeParticle()
    {
        smoke.SetActive(true);
        
        foreach (var item in smokes)
        {
            item.Play();
        }
    }

    private void OnCollider()
    {
        _collider.SetActive(true);
    }
    
    
}
