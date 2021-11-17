using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTRepeatUntilFail : BTNode
{
    public BTNode repeat;

    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;
        
        while (true)
        {
            yield return bt.StartCoroutine(repeat.Run(bt));

            if (repeat.status == Status.FAILURE)
            {
                status = Status.SUCCESS;
                break;
            }  
        }

    }
}
