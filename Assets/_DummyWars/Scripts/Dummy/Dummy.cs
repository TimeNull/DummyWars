using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dummy : MonoBehaviour
{
    protected BehaviourTree bt;

    //TODO: ScriptableObject here

    public float damage = 5;

    public float fireTime = 5;

    public float fireCooldown = 10;

    public GameObject bullet;

    public float bulletSpeed;

    public Transform firePoint;

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
        if(GameManager.Instance)
            GameManager.Instance.startGame -= StartBehaviour;
    }

    private void StartBehaviour() => StartCoroutine(bt.Begin());
}
