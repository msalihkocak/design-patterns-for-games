using StatePattern.States.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace StatePattern.States {
  public class Idle: NpcState {
    private static readonly int IsIdle = Animator.StringToHash("isIdle");

    public Idle(GameObject npc, NavMeshAgent agent, Animator animator, Transform playerTransform) : 
      base(npc, agent, animator, playerTransform) {
      Stop();
    }

    protected override void Enter() {
      Animator.SetTrigger(IsIdle);
      base.Enter();
    }

    protected override void Tick() {
      PursueIfPlayerIsVisible();
      if (Random.Range(0, 100) >= 10) return;
      NextState = new Patrol(Npc, Agent, Animator, PlayerTransform);
    }

    protected override void Exit() {
      Animator.ResetTrigger(IsIdle);
      base.Exit();
    }
  }
}