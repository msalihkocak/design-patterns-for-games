
using UnityEngine;

namespace Commands {
  public class Punch: AnimatorCommand {
    private static readonly int IsPunching = Animator.StringToHash("isPunching");
    private static readonly int IsPunchingBackwards = Animator.StringToHash("isPunchingBackwards");

    public override void Execute(Animator animator, bool isForward) {
      animator.SetTrigger(isForward ? IsPunching : IsPunchingBackwards);
    }

    public override void DeExecute(Animator animator) {
      
    }
  }
}