using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToMovingDirection : MonoBehaviour
{
    [SerializeField] private float angleInDegrees;

    private void Update() {
        LookWhereYouAreMoving(Move());
    }

    private void LookWhereYouAreMoving(Vector3 moveDirection) {
        // Normally on the line below x and z should be swapped according to the equations
        // But unity and conventional angle system differs.
        // To convert conventional angle system to unity -> (90 - angle)
        // Since sin and cos have this relation, simple swap does the trick.
        var directionEuler = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * directionEuler;
    }

    private Vector3 Move() {
        var moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0,
            Input.GetAxisRaw("Vertical")).normalized;
        transform.Translate(moveDirection * (Time.deltaTime * 3), Space.World);
        return moveDirection;
    }

    private void VisualizeInputAngle() {
        var direction = new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0,
            Mathf.Sin(angleInDegrees * Mathf.Deg2Rad));
        Debug.DrawRay(transform.position, direction * 1, Color.green);
    }
}
