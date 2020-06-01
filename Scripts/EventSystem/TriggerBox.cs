using System;
using UnityEngine;

namespace EventSystem {
  public class TriggerBox: MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
      if (!other.CompareTag("Player")) return;
      GameEvents.Current.DoorWayTriggerEnter();
    }

    private void OnTriggerExit(Collider other) {
      if (!other.CompareTag("Player")) return;
      GameEvents.Current.DoorWayTriggerExit();
    }
  }
}