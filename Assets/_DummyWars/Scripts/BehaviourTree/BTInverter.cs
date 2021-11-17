using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTInverter : BTNode
{
    public BTNode invert;

    public override IEnumerator Run(BehaviourTree bt)
    {
        yield return bt.StartCoroutine(invert.Run(bt));

        if (invert.status == Status.SUCCESS) status = Status.FAILURE;
        if (invert.status == Status.SUCCESS) status = Status.FAILURE;
    }
}
