using UnityEngine;

namespace EventSystem {
  public class PlayerController : MonoBehaviour {
    private float _speed = 4.0f;

    private void Update() {
      var velocityVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
      transform.Translate(velocityVector * (_speed * Time.deltaTime));
    }
  }
}