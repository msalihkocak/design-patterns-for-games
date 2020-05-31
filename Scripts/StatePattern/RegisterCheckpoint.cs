using UnityEngine;

namespace StatePattern {
  public class RegisterCheckpoint : MonoBehaviour {
    private void OnEnable() {
      EnvironmentElements.Instance.AddCheckpoint(gameObject);
    }

    private void OnDisable() {
      EnvironmentElements.Instance.RemoveCheckpoint(gameObject);
    }
  }
}