using System.Collections;
using UnityEngine;
using MyBox;


public class BehaviourTree : MonoBehaviour //responsavel pela propria behaviour tree
{
    public BTNode root; //node raiz (que � preenchido no script NPC_1

    [ReadOnly]
    public GameObject target;

    public IEnumerator Begin()
    {
        while (true)
        {
            yield return StartCoroutine(root.Run(this));
        }
    }
}

