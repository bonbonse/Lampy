using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss 
{
    public class BossBehaviour : MonoBehaviour
    {
        public Boss boss;
        public BossBehaviourHandler behaviourHandler;

        public virtual void Enter()
        {

        }
        public virtual void Exit()
        {

        }
        public virtual void Update()
        {
            LogicUpdate();
        }
        public virtual void FixedUpdate()
        {
            PhysicalUpdate();
        }
        public virtual void LogicUpdate()
        {
        }
        public virtual void PhysicalUpdate()
        {

        }
    }
}

