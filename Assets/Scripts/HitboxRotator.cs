using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class HitboxRotator : Rotator
{
    [Header("Config")]
    [SerializeField] float hitBoxBuffer = .75f;

    [Header("Model")]
    [SerializeField] GameObject parentSprite;

    Hitbox hitbox;

    // Start is called before the first frame update
    void Start() {
        hitbox = GetComponentInChildren<Hitbox>();
    }

    // Update is called once per frame
    void Update() {
        MoveHitbox();
    }

    private void MoveHitbox() {
        float xInput = Input.GetAxis(GameKeys.AXIS_HORIZONTAL_KEY);
        float yInput = Input.GetAxis(GameKeys.AXIS_VERTICAL_KEY);
        float angle = Mathf.Atan2(yInput, xInput) * Mathf.Rad2Deg;
        Vector2 inputVector = new Vector2(xInput, yInput);

        if (inputVector.magnitude < GameConfigConstants.INPUT_DEAD_ZONE) {
            hitbox.transform.localPosition = new Vector2(0, 0);
            return;
        }

        Bounds parentBounds = parentSprite.GetComponent<SpriteRenderer>().bounds;
        Vector2 newHitboxVector;
        if (inputVector.magnitude > parentBounds.size.x / 2) {
            newHitboxVector = new Vector2(parentBounds.size.x / 2 - hitBoxBuffer, 0);
        } else {
            newHitboxVector = new Vector2(inputVector.magnitude / parentBounds.size.x / 2, 0);
        }
        hitbox.transform.localPosition = newHitboxVector;

        RotateInstant(angle);
    }
}
