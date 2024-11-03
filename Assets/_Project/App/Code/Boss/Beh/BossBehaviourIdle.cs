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
            Debug.Log("Enter Idle");
            boss.PlayMusic(0);
            boss.StartCoroutine(WaitAndWalking());
            // boss.animator.Play("Idle");
        }
        public override void LogicUpdate()
        {
            if (boss.isIdle == false)
            {
                behaviourHandler.SetBehaviourWalking();
            }
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
            yield return new WaitForSeconds(boss.timeIdle);
            behaviourHandler.SetBehaviourWalking();
        }
    }
}
