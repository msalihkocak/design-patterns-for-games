using System;
using UnityEngine;

namespace EventSystem {
  public class GameEvents: MonoBehaviour {
    public static GameEvents Current;

    private void Awake() {
      Current = this;
    }

    public event Action OnDoorwayTriggerEnter;
    public void DoorWayTriggerEnter() => OnDoorwayTriggerEnter?.Invoke();
    
    public event Action OnDoorwayTriggerExit;
    public void DoorWayTriggerExit() => OnDoorwayTriggerExit?.Invoke();
  }
}