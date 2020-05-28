using System.Collections.Generic;
using UnityEngine;

namespace SingletonPattern {
  public sealed class GameEnvironment {
    private static GameEnvironment _instance;
    public static GameEnvironment Instance => _instance ?? (_instance = new GameEnvironment());

    private List<GameObject> _obstacles = new List<GameObject>();
    private List<GameObject> _goals = new List<GameObject>();

    private GameEnvironment() {
    }

    public Vector3 GetRandomGoal() {
      return _goals[Random.Range(0, _goals.Count)].transform.position;
    }

    public void AddObstacle(GameObject obstacle) {
      _obstacles.Add(obstacle);
    }

    public void RemoveObstacle(GameObject obstacle) {
      _obstacles.Remove(obstacle);
    }

    public void AddGoal(GameObject goal) {
      _goals.Add(goal);
    }

    public void RemoveGoal(GameObject goal) {
      _goals.Remove(goal);
    }
  }
}