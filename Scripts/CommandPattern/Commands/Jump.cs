
using UnityEngine;

namespace Commands {
  public class Jump: AnimatorCommand {
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsJumpingBackwards = Animator.StringToHash("isJumpingBackwards");

    public override void Execute(Animator animator, bool isForward) {
      animator.SetTrigger(isForward ? IsJumping : IsJumpingBackwards);
    }

    public override void DeExecute(Animator animator) {
    }
  }
}