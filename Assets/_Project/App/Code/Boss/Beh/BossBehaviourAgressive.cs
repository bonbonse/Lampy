using System.Diagnostics;

namespace Boss 
{
    public class BossBehaviourAgressive : BossBehaviour
    {
        public override void Enter()
        {
        }
        public override void LogicUpdate()
        {
           
        }
        public override void PhysicalUpdate()
        {
            boss.Move();
        }
        public override void Exit()
        {

        }
    }
}
