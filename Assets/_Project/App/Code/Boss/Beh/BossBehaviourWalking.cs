using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossBehaviourWalking : BossBehaviour
    {
        public override void Enter()
        {
            Debug.Log("enter waling");
        }
        public override void LogicUpdate()
        {
            if (boss.isIdle)
            {
                behaviourHandler.SetBehaviourIdle();
            }
        }
        public override void PhysicalUpdate()
        {
            boss.Move();
        }
        public override void Exit()
        {

        }
    }
}
