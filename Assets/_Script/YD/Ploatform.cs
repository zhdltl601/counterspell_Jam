using DG.Tweening;
using UnityEngine;

public class Ploatform : MonoBehaviour
{
    public Transform target;
    private Vector3 origin;
    private AudioSource audioSource;
    
    [SerializeField] private float time;
    [SerializeField] private LayerMask whatIsPlayer;

    [SerializeField] private Color greenColor;
    [SerializeField] private Color redColor;

    public Light PointLight;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        origin = transform.position;
        
        PointLight.color = redColor; 
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Vector3 realTarget = GameManager.CurrentState == GameState.A ? target.position : origin;
        
        PointLight.color = greenColor; 
        
        if((whatIsPlayer & (1 << other.gameObject.layer)) != 0)
        {
            other.gameObject.transform.SetParent(transform);
            transform.DOMove(realTarget, time).SetEase(Ease.InQuint).OnComplete(() =>
            {
                PointLight.color = redColor;
            });
            audioSource.Play();
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if((whatIsPlayer & (1 << other.gameObject.layer)) != 0)
        {
            other.gameObject.transform.SetParent(null);    
            PointLight.color = redColor;
        }
    }
    
}