using UnityEngine;

namespace StatePattern {
  public class GameSettings : MonoBehaviour {
    public static GameSettings Instance;
    
    public float distanceToBeDetected = 15.0f;
    public float angleToBeDetected = 30.0f;
    public float distanceToBeShot = 8.0f;

    private void Awake() {
      Instance = this;
    }
  }
}