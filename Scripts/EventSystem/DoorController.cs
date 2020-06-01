using System;
using UnityEngine;

namespace EventSystem {
  public class DoorController: MonoBehaviour {

    private Vector3 _doorOpenPosition;
    private Vector3 _doorClosedPosition;
    private bool _queOpen;
    private bool _queClose;
    
    private void Start() {
      _doorClosedPosition = transform.position;
      _doorOpenPosition = transform.position + Vector3.up * transform.localScale.y;
      GameEvents.Current.OnDoorwayTriggerEnter += OnDoorwayOpen;
      GameEvents.Current.OnDoorwayTriggerExit += OnDoorwayClose;
    }

    private void Update() {
      if (_queOpen) {
        transform.position = Vector3.Lerp(_doorOpenPosition, _doorClosedPosition, 0.001f);
        if (transform.position == _doorOpenPosition) _queOpen = false;
      }

      if (_queClose) {
        transform.position = Vector3.Lerp(_doorClosedPosition, _doorOpenPosition, 0.001f);
        if (transform.position == _doorClosedPosition) _queClose = false;
      }
    }

    private void OnDoorwayOpen() {
      _queOpen = true;
      _queClose = false;
    }
    
    private void OnDoorwayClose() {
      _queOpen = false;
      _queClose = true;
    }
  }
}