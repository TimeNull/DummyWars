using System.Collections;
using UnityEngine;


public abstract class BTNode //Blueprint de um node da behaviour tree
{
    public enum Status
    {
        FAILURE, RUNNING, SUCCESS
    }

    public Status status;

    public abstract IEnumerator Run(BehaviourTree bt);

    public void Print(BehaviourTree bt)
    {
        string cor = "yellow";

        if (status == Status.SUCCESS) cor = "green";
        else if (status == Status.FAILURE) cor = "magenta";

        Debug.Log($"<color=\"{cor}\"> {bt.gameObject.name} : {this.GetType().Name} </color> ");
    }
}

