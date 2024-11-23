using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEmitterBase : MonoBehaviour
{
    [SerializeField] protected List<AudioClip> audioClips;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void PlaySoundIdx(int indx = 0)
    {
        AudioClip clip = audioClips[indx];
        audioSource.PlayOneShot(clip);
    }
}
