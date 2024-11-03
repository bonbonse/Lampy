using Quest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBehaviourWorking : PlayerBehaviour
    {
        private bool _isGo = false;
        public override void Enter()
        {
            _isGo = true;
            player.animator.Play("Working");
            player.StartCoroutine(Tiring());
            player.StartCoroutine(Working());
            player.app.jobDone.TaskOn();

            QuestManager.CompleteQuest("Первый квест");
        }
        public override void HandleUpdate()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                behaviourHandler.SetBehaviourIdle();
                player.chair.gameObject.SetActive(true);
                player.chair = null;
            }
        }
        public override void LogicUpdate()
        {
            
        }
        public override void PhysicalUpdate()
        {
            base.PhysicalUpdate();
        }
        public override void Exit()
        {
            _isGo = false;
            // останавливает все корутины плейра! следует быть осторожнее
            player.StopAllCoroutines();
            player.app.jobDone.TaskOff();
        }
        IEnumerator Tiring()
        {
            yield return new WaitForSeconds(player.tiredSpeedInSeconds);
            if (_isGo)
            {
                player.app.fatique.AddProgress(player.tiredValueProgress);
                player.StartCoroutine(Tiring());
            }
        }
        IEnumerator Working()
        {
            yield return new WaitForSeconds(player.workSpeedInSeconds);
            if (_isGo)
            {
                player.app.jobDone.AddProgress(player.workValueProgress);
                player.StartCoroutine(Working());
            }
        }
    }
}
