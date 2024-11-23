using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private GameObject smoke;
    [SerializeField] private ParticleSystem[] smokes;
    
    [ContextMenu("Test")]
    public void OnSmokeParticle()
    {
        smoke.SetActive(true);
        
        foreach (var item in smokes)
        {
            item.Play();
        }
    }
}
