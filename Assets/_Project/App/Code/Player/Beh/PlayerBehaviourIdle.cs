using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class PlayerBehaviourIdle : PlayerBehaviour
    {
        public override void Enter()
        {
            Debug.Log("Idle Enter");
            player.animator.Play("Idle");
        }
        public override void HandleUpdate()
        {
            if ((player.moveDir.x = Input.GetAxis("Horizontal")) != 0) { }
            else if ((player.moveDir.y = Input.GetAxis("Vertical")) != 0) { }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player.chairSelected != null)
                {
                    Debug.Log(player.chairSelected);
                    behaviourHandler.SetBehaviourWorking();
                    player.Sit();
                }
            }
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    // TODO: тернарный оператор
            //    if (player.objInHand != null)
            //    {
            //        player.Drop();
            //    }
            //    else
            //    {
            //        player.Take();
            //    }
            //}

        }
        public override void LogicUpdate()
        {
            if (player.moveDir.x != 0 || player.moveDir.y != 0)
            {
                behaviourHandler.SetBehaviourWalking();
            }            
        }
        public override void PhysicalUpdate()
        {
            base.PhysicalUpdate();
        }
        public override void Exit()
        {

        }
    }
}