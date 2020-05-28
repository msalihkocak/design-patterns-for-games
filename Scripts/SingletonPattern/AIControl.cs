using SingletonPattern;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {
  private NavMeshAgent _agent;
  private Animator _anim;
  private Vector3 _lastGoal;

  private void Start() {
    _agent = this.GetComponent<NavMeshAgent>();
    _anim = GetComponent<Animator>();
    _anim.SetBool("isWalking", true);
    PickGoalLocation();
  }

  private void PickGoalLocation() {
    _lastGoal = _agent.destination;
    _agent.SetDestination(GameEnvironment.Instance.GetRandomGoal());
  }


  private void Update() {
    if (_agent.remainingDistance < 1) {
      PickGoalLocation();
    }
  }

  private void OnTriggerEnter(Collider other) {
    if (!other.CompareTag("Obstacle")) return;
    if (Random.Range(1, 100) > 90) {
      GameEnvironment.Instance.RemoveObstacle(other.gameObject);
      Destroy(other.gameObject);
    } else {
      _agent.SetDestination(_lastGoal);
    }
  }
}