using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BTMoveToOpponent : BTNode
{

    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        NavMeshAgent agent = bt.GetComponent<NavMeshAgent>();

        agent.updateRotation = false;

        while (true)
        {

            if(!agent.SetDestination(bt.target.transform.position))
            {
                status = Status.FAILURE;
                Print(bt);
                yield break;
            }

            Utility.RotateTowards(agent.transform, bt.target.transform.position, 30, true);

            if(agent.hasPath && agent.remainingDistance <= agent.stoppingDistance)
            {
                status = Status.SUCCESS;
                Print(bt);
                yield break;
            }

            yield return null;

        }
        
    }
}

