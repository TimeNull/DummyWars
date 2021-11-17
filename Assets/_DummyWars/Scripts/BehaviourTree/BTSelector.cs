using System.Collections;
using System.Collections.Generic;


public class BTSelector : BTNode  //Executa todos os nodes filhos em ordem, até que um resulte em sucesso
{
    private readonly List<BTNode> children = new List<BTNode>();
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        foreach(BTNode node in children)
        {
            yield return bt.StartCoroutine(node.Run(bt));
                
            if(node.status == Status.SUCCESS)
            {
                status = Status.SUCCESS;
                break;
            }
        }

        if(status == Status.RUNNING) status = Status.FAILURE;

    }
}
