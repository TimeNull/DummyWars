using System.Collections;
using UnityEngine;


public class BehaviourTree : MonoBehaviour //responsavel pela propria behaviour tree
{
    public BTNode root; //node raiz (que é preenchido no script NPC_1

    public IEnumerator Begin()
    {
        while (true)
        {
            yield return StartCoroutine(root.Run(this));
        }
    }
}

