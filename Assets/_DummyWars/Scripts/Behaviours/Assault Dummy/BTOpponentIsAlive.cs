using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BTOpponentIsAlive : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {

        if (bt.target.activeSelf)
            status = Status.SUCCESS;
        else
            status = Status.FAILURE;

        Print(bt);

        yield return null;
    }
}

