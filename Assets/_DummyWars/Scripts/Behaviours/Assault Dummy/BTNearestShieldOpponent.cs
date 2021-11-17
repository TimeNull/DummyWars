using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BTNearestShieldOpponent : BTNode
{

    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        const string TAG = "Enemy";

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(TAG);

        if (enemies.Length < 1)
        {
            status = Status.FAILURE;
            yield break;
        }

        GameObject target = null;
        float distance = Mathf.Infinity;

        foreach (GameObject obj in enemies)
        {
            if (obj.TryGetComponent(typeof(ShieldDummy), out _)) 
                continue;

            float startDistance = Vector3.Distance(bt.transform.position, obj.transform.position);

            if (distance > startDistance)
            {
                distance = startDistance;
                target = obj;
            }
            yield return null;
        }

        bt.target = target;

        yield return null;
    }
}

