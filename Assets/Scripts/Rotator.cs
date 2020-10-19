using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class Rotator : MonoBehaviour {
    [SerializeField] float rotationSpeed = 360f;

    public void SetRotationSpeed(float rotationSpeed) {
        this.rotationSpeed = rotationSpeed;
    }

    internal void RotateTowardsAngle(float angle) {
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);
    }

    internal void RotateInstant(float angle) {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

