using StatePattern.States;
using UnityEngine;
using UnityEngine.AI;

namespace StatePattern {
  public class NpcController : MonoBehaviour {
    [SerializeField] private Transform playerTransform;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private State _currentState;


    private void Start() {
      _navMeshAgent = GetComponent<NavMeshAgent>();
      _animator = GetComponent<Animator>();
      _currentState = new Idle(gameObject, _navMeshAgent, _animator, playerTransform);
    }

    private void Update() {
      _currentState = _currentState.Process();
    }
  }
}