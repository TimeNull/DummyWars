using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dummy : MonoBehaviour
{
    protected BehaviourTree bt;

    protected virtual void Awake()
    {
        bt = GetComponent<BehaviourTree>();
    }

    protected virtual void Start()
    {
        InitializeBehaviourTree();
    }

    protected abstract void InitializeBehaviourTree();

    private void OnEnable()
    {
        GameManager.Instance.startGame += StartBehaviour;
    }

    private void OnDisable()
    {
        GameManager.Instance.startGame -= StartBehaviour;
    }

    private void StartBehaviour() => StartCoroutine(bt.Begin());
}
