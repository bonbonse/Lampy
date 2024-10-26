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
            if ((player.moveDir.x = Input.GetAxis("Horizontal")) != 0) 
            { 
                player.moveDir.y = 0;
            }
            if ((player.moveDir.y = Input.GetAxis("Vertical")) != 0) 
            { 
                player.moveDir.x = 0; 
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player.chairSelected != null)
                {
                    player.Sit();
                    behaviourHandler.SetBehaviourWorking();
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
            if (player.moveDir.x == 0 && player.moveDir.y == 0)
            {
                behaviourHandler.SetBehaviourIdle();
            }
            else
            {
                CheckMoveDirectionAndPlayAnim();
            }
        }
        public override void PhysicalUpdate()
        {
            player.Move();
        }
        public override void Exit()
        {

        }

        private void CheckMoveDirectionAndPlayAnim()
        {
            // -1 - idle, 0 - up, 1 - down, 2 - side   -- TODO:  Enum
            if (player.moveDir.x != 0)
            {
                if (player.moveDir.x < 0)
                {
                    player.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    player.transform.localScale = new Vector3(-1, 1, 1);
                }
                player.animator.Play("MoveSide");

            }
            else
            {
                if (player.moveDir.y > 0)
                {
                    player.animator.Play("MoveUp");
                }
                else
                {
                    player.animator.Play("MoveDown");
                }
            }
        }
    }
}