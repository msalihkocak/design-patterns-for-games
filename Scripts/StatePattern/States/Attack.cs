using StatePattern.States.Abstract;
using UnityEngine;
using UnityEngine.AI;

namespace StatePattern.States {
  public class Attack: NpcState {
    private static readonly int IsShooting = Animator.StringToHash("isShooting");

    public Attack(GameObject npc, NavMeshAgent agent, Animator animator, Transform playerTransform) 
      : base(npc, agent, animator, playerTransform) {
      Stop();
    }

    protected override void Enter() {
      Animator.SetTrigger(IsShooting);
      base.Enter();
    }

    protected override void Tick() {
      Npc.transform.LookAt(PlayerTransform);
      if (CanAttackTarget()) return; 
      PursueIfPlayerIsVisible();
      IdleIfTargetIsNotVisible();
    }

    protected override void Exit() {
      Animator.ResetTrigger(IsShooting);
      base.Exit();
    }
  }
}