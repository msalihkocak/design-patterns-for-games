using UnityEngine;

namespace Commands {
  public abstract class AnimatorCommand {
    public abstract void Execute(Animator animator, bool isForward);
    public abstract void DeExecute(Animator animator);
  }
}