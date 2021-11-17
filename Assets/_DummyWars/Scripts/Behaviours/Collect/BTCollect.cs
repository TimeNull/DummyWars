using System.Collections;
using UnityEngine;


public class BTCollect : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.FAILURE;

        const string TAG = "Collectable";
        GameObject[] collectables = GameObject.FindGameObjectsWithTag(TAG);

        foreach (GameObject obj in collectables)
        {
            Vector3 objWithoutY = new Vector3(obj.transform.position.x, 0, obj.transform.position.z);
            if (Vector3.Distance(bt.transform.position, objWithoutY) <= 1)
            {
                obj.SetActive(false); //fazer pool de objetos
                status = Status.SUCCESS;
                break;
            }
        }

        Print(bt);

        yield break;
    }
}
