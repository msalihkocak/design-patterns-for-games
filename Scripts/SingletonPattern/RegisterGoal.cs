using UnityEngine;

namespace SingletonPattern {
  public class RegisterGoal : MonoBehaviour {
    private void OnEnable() {
      GameEnvironment.Instance.AddGoal(gameObject);
    }

    private void OnDisable() {
      GameEnvironment.Instance.RemoveGoal(gameObject);
    }
  }
}