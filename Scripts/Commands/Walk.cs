
using UnityEngine;

namespace Commands {
  public class Walk: AnimatorCommand {
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsWalkingBackwards = Animator.StringToHash("isWalkingBackwards");

    public override void Execute(Animator animator, bool isForward) {
      animator.SetTrigger(isForward ? IsWalking : IsWalkingBackwards);
    }

    public override void DeExecute(Animator animator) {
      animator.SetBool(IsWalking, false);
    }
  }
}