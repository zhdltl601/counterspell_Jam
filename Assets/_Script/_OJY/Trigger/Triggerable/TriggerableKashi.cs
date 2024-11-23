using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerableKashi : TriggerableObjectBase, IOnExitReciver
{
    private bool isActivated;
    [SerializeField] Vector3 endPosition;
    [SerializeField] private float endTime = 0.25f;
    [SerializeField] private Transform kashi;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private AudioEmitterBase emitter;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            OnExitRecive();
    }
    public void OnExitRecive()
    {
        if (isActivated) return;
        isActivated = true;
        emitter.PlaySoundIdx();
        StartCoroutine(KashiAttack());
        IEnumerator KashiAttack()
        {
            yield return new WaitForSeconds(0.4f);
            float timer = 0;
            Vector3 initialPosition = transform.position;
            while (timer <= endTime)
            {
                timer += Time.deltaTime;
                float value = timer / endTime;
                kashi.position = Vector3.Lerp(initialPosition, transform.position + endPosition, curve.Evaluate(value));
                yield return null;
            }
            kashi.position = transform.position + endPosition;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + endPosition);
    }
}
