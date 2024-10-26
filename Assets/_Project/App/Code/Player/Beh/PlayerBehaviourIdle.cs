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
            // меняем спрайт на стоящего и смотрящего в экран
        }
        public override void HandleUpdate()
        {
            player.moveDir.x = Input.GetAxis("Horizontal");
            player.moveDir.y = Input.GetAxis("Vertical");
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                // TODO: тернарный оператор
                if (player.objInHand != null)
                {
                    player.Drop();
                }
                else
                {
                    player.Take();
                }
            }

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