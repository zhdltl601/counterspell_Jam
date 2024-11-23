using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActiver : MonoBehaviour
{
    private Collider baseCollider;
    private void Awake()
    {
        baseCollider = GetComponent<Collider>();
    }
    public void SetColliderActive(bool active)
    {
        baseCollider.enabled = active;
    }
}
