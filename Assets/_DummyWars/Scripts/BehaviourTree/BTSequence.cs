using System.Collections;
using System.Collections.Generic;


class BTSequence : BTNode //Executa todos os nodes filhos em ordem, até que um resulte em falha, ou todos sejam completados
{
    public List<BTNode> children = new List<BTNode>();
        
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        foreach(BTNode node in children)
        {
            yield return bt.StartCoroutine(node.Run(bt));

            if (node.status == Status.FAILURE)
            {
                status = Status.FAILURE;
                break;
            }
        }

        if (status == Status.RUNNING) status = Status.SUCCESS;
    }
}

