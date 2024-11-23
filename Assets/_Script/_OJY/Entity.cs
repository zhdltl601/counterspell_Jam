using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private readonly Dictionary<Type, IEntityComponent> componentDictionary = new();
    protected virtual void Awake()
    {
        var componentList =
            GetComponentsInChildren<IEntityComponent>(true).
            ToList();
        componentList.ForEach(x => InitializeEntityComponent(x));
    }
    protected virtual void Start()
    {
        var componentList =
            GetComponentsInChildren<IEntityComponent>(true).
            ToList();
        componentList.ForEach(x =>
        {
            if (x is IEntityComponentStartInit entityStartInit) entityStartInit.EntityComponentStartInit(this);
        });
    }
    private IEntityComponent InitializeEntityComponent(IEntityComponent component)
    {
        componentDictionary.Add(component.GetType(), component);
        component.EntityComponentAwake(this);
        return component;
    }
    public T GetEntityComponent<T>() where T : Component, IEntityComponent
    {
        if (componentDictionary.TryGetValue(typeof(T), out IEntityComponent value))
        {
            return value as T;
        }
        Debug.LogError("[ERROR]can't find Entity_Component, reInitializing...");
        T componentInstance = GetComponentInChildren<T>(true);
        return InitializeEntityComponent(componentInstance) as T;
    }
    private void OnDestroy()
    {
        var componentList =
            GetComponentsInChildren<IEntityComponent>(true).
            ToList();
        componentList.ForEach(x =>
        {
            if (x is IEntityComponentDispose entityDisposeable) entityDisposeable.Dispose(this);
        });
    }
}
