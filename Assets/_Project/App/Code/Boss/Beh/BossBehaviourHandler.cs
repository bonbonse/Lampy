using Boss;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossBehaviourHandler : MonoBehaviour
    {
        //Behaviours
        private Dictionary<Type, BossBehaviour> behavioursMap;
        private BossBehaviour behaviourCurrent;
        private Boss boss;
        private BossBehaviourHandler behaviourHandler;

        private void Start()
        {
            boss = GetComponent<Boss>();
            behaviourHandler = GetComponent<BossBehaviourHandler>();

            InitBehaviours();
            SetBehaviourByDefault();
        }
        private void InitBehaviours()
        {
            behavioursMap = new Dictionary<Type, BossBehaviour>();

            behavioursMap[typeof(BossBehaviourAgressive)] = new BossBehaviourAgressive();
            behavioursMap[typeof(BossBehaviourIdle)] = new BossBehaviourIdle();
        }
        private void Update()
        {
            if (behaviourCurrent != null)
                behaviourCurrent.Update();
        }
        private void FixedUpdate()
        {
            if (behaviourCurrent != null)
                behaviourCurrent.FixedUpdate();
        }

        private void SetBehaviour(BossBehaviour newBehaviour)
        {
            if (behaviourCurrent != null)
                behaviourCurrent.Exit();
            behaviourCurrent = newBehaviour;
            behaviourCurrent.boss = boss;
            behaviourCurrent.behaviourHandler = behaviourHandler;
            behaviourCurrent.Enter();
        }
        private void SetBehaviourByDefault()
        {
            var behaviourByDefault = GetBehaviour<BossBehaviourIdle>();
            SetBehaviour(behaviourByDefault);
        }

        private BossBehaviour GetBehaviour<T>() where T : BossBehaviour
        {
            var type = typeof(T);
            return behavioursMap[type];
        }

        public void SetBehaviourIdle()
        {
            var behaviour = GetBehaviour<BossBehaviourIdle>();
            SetBehaviour(behaviour);
        }
        public void SetBehaviourAgressive()
        {
            var behaviour = GetBehaviour<BossBehaviourAgressive>();
            SetBehaviour(behaviour);
        }
    }
}
