using System.Collections;
using UnityEngine;
using MyBox;


public sealed class BTMoveToCollectable : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        const string TAG = "Collectable";

        GameObject[] collectables = GameObject.FindGameObjectsWithTag(TAG);
        GameObject target = null;
        float distance = Mathf.Infinity;

        foreach(GameObject obj in collectables)
        {
            float startDistance = Vector3.Distance(bt.transform.position, obj.transform.position);
            if(distance > startDistance)
            {
                distance = startDistance;
                target = obj;
            }
            yield return null;
        }
        while (target.activeSelf)
        {
            //checar se isso funfa    
            float dist = Vector3.Distance(bt.transform.position.ToVector2(), target.transform.position.ToVector2());

            Debug.Log(dist);

            if (dist <= 1)
            {
                status = Status.SUCCESS;
                break;
            }

            Utility.RotateTowards(bt.transform, target.transform.position, 5, true);
            bt.transform.Translate(Vector3.forward * Time.deltaTime * 5);
            yield return null;
        }

        if(status == Status.RUNNING) status = Status.FAILURE;

        Print(bt);

    }
      
}
