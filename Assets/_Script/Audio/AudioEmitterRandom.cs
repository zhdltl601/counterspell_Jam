using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEmitterRandom : AudioEmitterBase
{
    public override void PlaySoundIdx(int indx = 0)
    {
        int randomIdx = Random.Range(0, audioClips.Count);
        base.PlaySoundIdx(randomIdx);
    }
}
