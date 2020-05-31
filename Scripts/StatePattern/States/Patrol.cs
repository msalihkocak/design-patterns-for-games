using StatePattern.States.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace StatePattern.States {
  public class Patrol : NpcState {
    private int _currentIndex = -1;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    public Patrol(GameObject npc, NavMeshAgent agent, Animator animator, Transform playerTransform) : base(npc, agent,
      animator, playerTransform) {
      Walk();
    }

    protected override void Enter() {
      _currentIndex = 0;
      Animator.SetTrigger(IsWalking);
      base.Enter();
    }

    protected override void Tick() {
      if (Agent.remainingDistance < 1) {
        if (_currentIndex < EnvironmentElements.Instance.GetCheckpointCount() - 1) _currentIndex++;
        else _currentIndex = 0;
        Agent.SetDestination(EnvironmentElements.Instance.GetCheckpointAtIndex(_currentIndex));
      }
      PursueIfPlayerIsVisible();
    }

    protected override void Exit() {
      Animator.ResetTrigger(IsWalking);
      base.Exit();
    }
  }
}