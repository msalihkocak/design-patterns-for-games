using UnityEngine;

namespace SingletonPattern {
  public class CreateEnvironmentElement : MonoBehaviour {
    public GameObject garbage;
    public GameObject goal;

    void Update() {
      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (!Physics.Raycast(ray.origin, ray.direction, out var hitInfo)) return;

      if (Input.GetMouseButtonDown(0)) {
        GameEnvironment.Instance.AddObstacle(Instantiate(garbage, hitInfo.point, Quaternion.identity));
      }

      if (Input.GetMouseButtonDown(1)) {
        GameEnvironment.Instance.AddObstacle(Instantiate(goal, hitInfo.point, Quaternion.identity));
      }
    }
  }
}