using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;
using ObjectMovers;

public class HitboxRotator : Rotator
{
    [SerializeField] float hitBoxOuterBuffer = .2f;
    [SerializeField] GameObject parentSprite;
    Hitbox hitbox;

    // Start is called before the first frame update
    void Start() {
        hitbox = FindObjectOfType<Hitbox>();
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
        } else {
            Bounds parentBounds = parentSprite.GetComponent<SpriteRenderer>().bounds;
            hitbox.transform.localPosition = new Vector2(inputVector.magnitude / parentBounds.size.x / 2, 0);
        }
        
        Debug.Log(hitbox.transform.localPosition);
        RotateInstant(angle);
    }
}
