﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class MainCharacter : MonoBehaviour
{
    [Header("Movement And Action Config")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float midairReverseSpeed = 2f;
    [SerializeField] float jumpSpeed = 12f;
    [SerializeField] int abilitycap = 1;

    Ability ability;
    BoxCollider2D mainCharacterFeetCollider;
    Rigidbody2D mainCharacterRigidbody;
    Health health;

    float jumpXSpeed = 0;
    bool hasReversedInMidair = false;
    bool isTouchingGround = true;

    // Start is called before the first frame update
    void Start() {
        mainCharacterRigidbody = GetComponent<Rigidbody2D>();
        mainCharacterFeetCollider = GetComponent<BoxCollider2D>();
        ability = GetComponentInChildren<Ability>();
        health = GetComponentInChildren<Health>();
    }

    // Update is called once per frame
    void Update() {
        UpdateMidair();
        Move();
        Jump();
        Attack();
    }

    private void Move() {
        if (!Input.GetButton(GameKeys.AXIS_HORIZONTAL_KEY)) { return; }
        
        float selectedSpeed;
        float xInput = Input.GetAxis(GameKeys.AXIS_HORIZONTAL_KEY);

        bool isReversing = Mathf.Sign(xInput) != Mathf.Sign(jumpXSpeed) && Mathf.Abs(jumpXSpeed) > Mathf.Epsilon;

        if ((!isTouchingGround && isReversing) || hasReversedInMidair) {
            selectedSpeed = midairReverseSpeed;
            hasReversedInMidair = true;
        } else {
            selectedSpeed = moveSpeed;
        }

        float newX = Mathf.Sign(xInput) * selectedSpeed;
        jumpXSpeed = isTouchingGround ? 0f : newX;
        Vector2 newVelocity = new Vector2(newX, mainCharacterRigidbody.velocity.y);
        mainCharacterRigidbody.velocity = newVelocity;
    }         

    private void Jump() {
        if (!isTouchingGround || !Input.GetButtonDown(GameKeys.AXIS_JUMP_KEY)) { return; }
        float currentXSpeed = mainCharacterRigidbody.velocity.x;
        if (Mathf.Abs(currentXSpeed) < GameConfigConstants.GAME_JUMP_MINIMUM_X_THRESHOLD) {
            jumpXSpeed = 0f;
        } else {
            jumpXSpeed = mainCharacterRigidbody.velocity.x;
        }

        Vector2 newVelocity = new Vector2(mainCharacterRigidbody.velocity.x, jumpSpeed);
        mainCharacterRigidbody.velocity = newVelocity;
        
    }

    private void Attack() {
        bool isAttacking = Input.GetButtonDown(GameKeys.AXIS_FIRE_1_KEY);

        if (isAttacking) {
            ability.Activate();
        }
    }

    private void UpdateMidair() {
        isTouchingGround = mainCharacterFeetCollider.IsTouchingLayers(LayerMask.GetMask(GameKeys.LAYER_GROUND_KEY));
        if (isTouchingGround) {
            hasReversedInMidair = false;
        }
    }

    
}
