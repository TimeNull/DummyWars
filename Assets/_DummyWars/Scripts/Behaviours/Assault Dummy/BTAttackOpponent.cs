using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BTAttackOpponent : BTNode
{

    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.RUNNING;

        Print(bt);

        Dummy dummy = bt.transform.GetComponent<Dummy>();

        float fireTime = dummy.fireTime;

        while(fireTime > 0)
        {
            fireTime -= 0.3f;
            Bullet a = Object.Instantiate(dummy.bullet, dummy.firePoint.position, Quaternion.identity).GetComponent<Bullet>();
            a.Setup(dummy.firePoint.forward, dummy.bulletSpeed, dummy.damage, 5, bt.gameObject.layer);
            yield return new WaitForSeconds(dummy.fireCooldown);
        }

        status = Status.SUCCESS;

        yield break;

    }
}

