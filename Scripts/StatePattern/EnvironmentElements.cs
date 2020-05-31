using System.Collections.Generic;
using UnityEngine;

namespace StatePattern {
  public sealed class EnvironmentElements {
    private static EnvironmentElements _instance;
    public static EnvironmentElements Instance => _instance ?? (_instance = new EnvironmentElements());
    
    private List<GameObject> _checkpoints = new List<GameObject>();
    
    private EnvironmentElements(){}

    public int GetCheckpointCount() {
      return _checkpoints.Count;
    }

    public Vector3 GetCheckpointAtIndex(int index) {
      return _checkpoints[index].transform.position;
    }

    public void AddCheckpoint(GameObject checkpoint) {
      _checkpoints.Add(checkpoint);
    }

    public void RemoveCheckpoint(GameObject checkpoint) {
      _checkpoints.Remove(checkpoint);
    }
  }
}