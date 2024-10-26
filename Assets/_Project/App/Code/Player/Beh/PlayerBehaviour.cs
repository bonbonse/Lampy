using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class PlayerBehaviour
    {
        public Player player;
        public PlayerBehaviourHandler behaviourHandler;

        public virtual void Enter()
        {

        }
        public virtual void Exit()
        {

        }
        public virtual void Update()
        {
            HandleUpdate();
            LogicUpdate();
        }
        public virtual void FixedUpdate()
        {
            PhysicalUpdate();
        }

        public virtual void LogicUpdate()
        {
        }
        public virtual void HandleUpdate()
        {

        }
        public virtual void PhysicalUpdate()
        {

        }
        public virtual void BehaviourUpdate()
        {

        }
    }
}