
using UnityEngine;

namespace Commands {
  public class Kick: AnimatorCommand {
    private static readonly int IsKicking = Animator.StringToHash("isKicking");
    private static readonly int IsKickingBackwards = Animator.StringToHash("isKickingBackwards");

    public override void Execute(Animator animator, bool isForward) {
      animator.SetTrigger(isForward ? IsKicking : IsKickingBackwards);
    }

    public override void DeExecute(Animator animator) {
    }
  }
}