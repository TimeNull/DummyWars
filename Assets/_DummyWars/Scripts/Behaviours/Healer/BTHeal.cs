using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTHeal : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        yield return null;
    }
}
