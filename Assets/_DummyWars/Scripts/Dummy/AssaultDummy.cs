using UnityEngine;

[RequireComponent(typeof(BehaviourTree))]
public class AssaultDummy : Dummy
{


    protected override void InitializeBehaviourTree()
    {
        BehaviourTree bt = GetComponent<BehaviourTree>();

        BTSelector check = new BTSelector();
        check.children.Add(new BTNearestShieldOpponent());
        check.children.Add(new BTNearestOpponent());

        BTMoveToOpponent move = new BTMoveToOpponent();

        BTSequence combat = new BTSequence();
        combat.children.Add(new BTOpponentIsAlive());
        combat.children.Add(new BTAttackOpponent());
        combat.children.Add(new BTDodgeOpponent());

        BTRepeatUntilFail loopCombat = new BTRepeatUntilFail();
        loopCombat.repeat = combat;

        BTSequence root = new BTSequence();
        root.children.Add(check);
        root.children.Add(move);
        root.children.Add(loopCombat);

        bt.root = root;
    }


}

