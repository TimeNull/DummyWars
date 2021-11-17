using System.Collections;
using UnityEngine;


public sealed class BTHasCollectable : BTNode //node "Leaf" exemplo, responsavel por apenas uma acao ou checagem de condição especifica
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        const string TAG = "Collectable";
        GameObject collectable = GameObject.FindWithTag(TAG);

        if (collectable) status = Status.SUCCESS;
        else status = Status.FAILURE;

        Print(bt);

        yield break;
    }
}
