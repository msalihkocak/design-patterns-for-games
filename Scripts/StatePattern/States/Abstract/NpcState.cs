using UnityEngine;
using UnityEngine.AI;

namespace StatePattern.States.Abstract {
  public abstract class NpcState: State {
    
    protected readonly GameObject Npc;
    protected readonly Animator Animator;
    protected readonly Transform PlayerTransform;
    protected readonly NavMeshAgent Agent;

    protected NpcState(GameObject npc, NavMeshAgent agent, Animator animator, Transform playerTransform) {
      Npc = npc;
      Agent = agent;
      Animator = animator;
      PlayerTransform = playerTransform;
      Stage = StageType.Enter;
    }
    
    private void SetNavAgentParams(bool isStopped, float speed) {
      Agent.isStopped = isStopped;
      Agent.speed = speed;
    }

    protected void Stop() {
      SetNavAgentParams(true, 0);
    }

    protected void Walk() {
      SetNavAgentParams(false, 2);
    }

    protected void Run() {
      SetNavAgentParams(false, 5);
    }

    private bool CanSeePlayer() {
      var positionDifferenceVector = PlayerTransform.position - Npc.transform.position;
      var isInPositionRange = positionDifferenceVector.sqrMagnitude < Mathf.Pow(GameSettings.Instance.distanceToBeDetected, 2);
      var isInAngleRange = Mathf.Abs(Vector3.Angle(Npc.transform.forward, positionDifferenceVector)) < GameSettings.Instance.angleToBeDetected;
      return isInPositionRange && isInAngleRange;
    }
    
    protected bool CanAttackTarget() {
      return (PlayerTransform.position - Npc.transform.position).sqrMagnitude < Mathf.Pow(GameSettings.Instance.distanceToBeShot, 2);
    }

    protected void IdleIfTargetIsNotVisible() {
      if (CanSeePlayer()) return;
      NextState = new Idle(Npc, Agent, Animator, PlayerTransform);
    }

    protected void PursueIfPlayerIsVisible() {
      if (!CanSeePlayer()) return;
      NextState = new Pursue(Npc, Agent, Animator, PlayerTransform);
    }
  }
}