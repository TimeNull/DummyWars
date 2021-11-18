using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTDodgeOpponent : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {

        status = Status.RUNNING;

        Print(bt);

        float direction = Random.Range(-1, 2);

        NavMeshAgent agent = bt.transform.GetComponent<NavMeshAgent>();

        float timeDodge = 0.5f;
        float _timeDodge = timeDodge;

        while (bt.target.activeSelf)
        {
            bt.transform.LookAt(bt.target.transform);
            agent.transform.Translate(Vector3.right * direction * 3 * Time.deltaTime);
            Print(bt);

            _timeDodge -= Time.deltaTime;

            if (_timeDodge <= 0) 
            {
                status = Status.SUCCESS;
                Print(bt);
                yield break; 
            }

            yield return null;
        }

        if (status == Status.RUNNING) status = Status.FAILURE;
    }
}

