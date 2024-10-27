using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossBehaviourIdle : BossBehaviour
    {
        public override void Enter()
        {
            Debug.Log("Idle");
            boss.StartCoroutine(WaitAndWalking());
            // boss.animator.Play("Idle");
        }
        public override void LogicUpdate()
        {
            //if (boss.moveDir.x != 0 || boss.moveDir.y != 0)
            //{
            //    behaviourHandler.SetBehaviourAgressive();
            //}
        }
        public override void PhysicalUpdate()
        {
            
        }
        public override void Exit()
        {
            boss.isIdle = false;
        }
        IEnumerator WaitAndWalking()
        {
            yield return new WaitForSeconds(5);
            behaviourHandler.SetBehaviourWalking();
        }
    }
}
