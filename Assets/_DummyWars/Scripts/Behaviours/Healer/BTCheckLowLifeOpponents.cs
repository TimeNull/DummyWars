using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTCheckLowLifeOpponents : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);
        
        const string Ally = "Ally";

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Ally);

        if (enemies.Length < 1)
        {
            status = Status.FAILURE;
            Print(bt);
            yield break;
        }

        GameObject target = null;
        float distance = Mathf.Infinity;

        foreach (GameObject obj in enemies)
        {
            float startDistance = Vector3.Distance(bt.transform.position, obj.transform.position);

            if (distance > startDistance)
            {
                distance = startDistance;
                target = obj;
            }

            yield return null;
        }

        if (!target)
        {
            status = Status.FAILURE;
            Print(bt);
            yield break;
        }

        bt.target = target;
        status = Status.SUCCESS;
        Print(bt);

    }
}
