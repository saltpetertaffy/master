using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;
using ObjectMovers;

public class DirectionIndicator : MonoBehaviour
{
    [SerializeField] GameObject directionIndicatorPrefab;
    [SerializeField] float rotationSpeed = 360f;

    Rotator rotator;

    private void Start() {
        rotator = GetComponent<Rotator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate() {
        float horizontalInput = Input.GetAxis(GameKeys.AXIS_HORIZONTAL_KEY);
        float verticalInput = Input.GetAxis(GameKeys.AXIS_VERTICAL_KEY);
        float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        bool isAttemptingToMove = Mathf.Abs(direction.sqrMagnitude) > GameConfigConstants.INPUT_DEAD_ZONE;
        if (!isAttemptingToMove) {
            directionIndicatorPrefab.SetActive(false);
            return;
        }

        if (directionIndicatorPrefab.activeSelf) {
            rotator.RotateTowardsAngle(angle);
            return;
        }

        directionIndicatorPrefab.SetActive(true);
        rotator.RotateInstant(angle);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);     
    }
}
