using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBehaviourWalking : PlayerBehaviour
    {
        public override void Enter()
        {
            Debug.Log("Walk Enter");
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
            if (player.moveDir.x == 0 && player.moveDir.y == 0)
            {
                behaviourHandler.SetBehaviourIdle();
            }
            // TODO: поворот персонажа
        }
        public override void PhysicalUpdate()
        {
            player.Move();
        }
        public override void Exit()
        {

        }
    }
}