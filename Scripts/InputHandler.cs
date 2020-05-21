using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;

public class InputHandler : MonoBehaviour {
  [SerializeField] private GameObject player;

  private float _movSpeed = 2f, _rotSpeed = 50f;
  private Animator _animator;
  private AnimatorCommand _walk, _jump, _kick, _punch;
  private const float VerticalTolerance = 0.0001f;

  private List<AnimatorCommand> _oldCommands = new List<AnimatorCommand>();
  private Coroutine _replayCoroutine;
  private bool _shouldStartReplay;
  private bool _isReplaying;

  private void Start() {
    _walk = new Walk();
    _jump = new Jump();
    _kick = new Kick();
    _punch = new Punch();
    _animator = player.GetComponent<Animator>();
  }

  private void Update() {
    UpdateTransform();
    UpdateAnimation();
  }

  private void UpdateTransform() {
    var translation = Input.GetAxis("Vertical") * _movSpeed * Time.deltaTime;
    var rotation = Input.GetAxis("Horizontal") * _rotSpeed * Time.deltaTime;

    player.transform.Translate(0, 0, translation);
    player.transform.Rotate(0, rotation, 0);
  }

  private void UpdateAnimation() {
    if (Math.Abs(Input.GetAxis("Vertical")) > VerticalTolerance) _walk.Execute(_animator, true);
    else _walk.DeExecute(_animator);
    if (Input.GetKeyDown(KeyCode.Space)) _jump.Execute(_animator, true);
    if (Input.GetKeyDown(KeyCode.Mouse0)) _kick.Execute(_animator, true);
    if (Input.GetKeyDown(KeyCode.Mouse1)) _punch.Execute(_animator, true);
    if (Input.GetKeyDown(KeyCode.Z)) UndoLastCommand();
  }

  private void UndoLastCommand() {
    if (_oldCommands.Count <= 0) return;
    var c = _oldCommands[_oldCommands.Count - 1];
    c.Execute(_animator, false);
    _oldCommands.RemoveAt(_oldCommands.Count - 1);
  }

  private void StartReplay() {
    if (!_shouldStartReplay || _oldCommands.Count <= 0) return;
    _shouldStartReplay = false;
    if (_replayCoroutine != null) {
      StopCoroutine(_replayCoroutine);
    }

    _replayCoroutine = StartCoroutine(ReplayCommands());
  }

  protected virtual IEnumerator ReplayCommands() {
    _isReplaying = true;

    foreach (var command in _oldCommands) {
      command.Execute(_animator, true);
      yield return new WaitForSeconds(1f);
    }

    _isReplaying = false;
  }
}