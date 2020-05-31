using StatePattern.States.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace StatePattern.States {
  public class Pursue: NpcState {
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    public Pursue(GameObject npc, NavMeshAgent agent, Animator animator, Transform playerTransform) 
      : base(npc, agent, animator, playerTransform) {
      Run();
    }

    protected override void Enter() {
      Animator.SetTrigger(IsRunning);
      base.Enter();
    }

    protected override void Tick() {
      Agent.SetDestination(PlayerTransform.position);
      Npc.transform.LookAt(PlayerTransform);
      IdleIfTargetIsNotVisible();
      if (!CanAttackTarget()) return;
      NextState = new Attack(Npc, Agent, Animator, PlayerTransform);
    }

    protected override void Exit() {
      Animator.ResetTrigger(IsRunning);
      base.Exit();
    }
  }
}