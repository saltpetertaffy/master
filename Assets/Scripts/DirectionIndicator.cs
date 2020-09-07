using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;
using ObjectMovers;

public class DirectionIndicator : Rotator
{
    [SerializeField] GameObject directionIndicatorPrefab;

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
            RotateTowardsAngle(angle);
            return;
        }

        directionIndicatorPrefab.SetActive(true);
        RotateInstant(angle);    
    }
}
