using System.Collections;
using UnityEngine;
using GameConstants;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;

public class MainCharacter : Character, IMortal {
    Ability activeAbility { get; set; }
    BoxCollider2D mainCharacterFeetCollider;
    Rigidbody2D mainCharacterRigidbody;
    EquippedAbilitySelector abilities;
    CharacterLoader characterLoader;

    float jumpXSpeed = 0;
    bool hasReversedInMidair = false;
    bool isTouchingGround = true;
    bool canAttack = true;

    // Start is called before the first frame update
    void Start() {
        mainCharacterRigidbody = GetComponent<Rigidbody2D>();
        mainCharacterFeetCollider = GetComponent<BoxCollider2D>();
        abilities = FindObjectOfType<EquippedAbilitySelector>();
        activeAbility = Instantiate(abilities.GetActiveAbility(), gameObject.transform);
    }

    // Update is called once per frame
    void Update() {
        Die();
        if (!activeAbility) {
            activeAbility = abilities.GetActiveAbility();
        }
        UpdateMidair();
        Move();
        Jump();
        Attack();
        CycleAbility();
    }

    private void Move() {
        if (!Input.GetButton(GameKeys.AXIS_HORIZONTAL_KEY)) { return; }
        
        float selectedSpeed;
        float xInput = Input.GetAxis(GameKeys.AXIS_HORIZONTAL_KEY);

        bool isReversing = Mathf.Sign(xInput) != Mathf.Sign(jumpXSpeed) && Mathf.Abs(jumpXSpeed) > Mathf.Epsilon;

        if ((!isTouchingGround && isReversing) || hasReversedInMidair) {
            selectedSpeed = GetGameStatByKey("MOVEMENT_MIDAIR_REVERSE_SPEED").GetCurrentValue();
            hasReversedInMidair = true;
        } else {
            selectedSpeed = GetGameStatByKey("MOVEMENT_MOVE_SPEED").GetCurrentValue();
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

        Vector2 newVelocity = new Vector2(mainCharacterRigidbody.velocity.x, GetGameStatByKey("MOVEMENT_JUMP_SPEED").GetCurrentValue());
        mainCharacterRigidbody.velocity = newVelocity;
        
    }

    private void Attack() {
        bool isAttacking = Input.GetButtonDown(GameKeys.AXIS_FIRE_1_KEY);

        if (isAttacking && canAttack) {
            canAttack = false;
            activeAbility.Activate();
            StartCoroutine(DelayAttack());
        }
    }

    private void CycleAbility() {
        bool selectingNextAbility = Input.GetButtonDown(GameKeys.AXIS_CYCLE_EQUIP_KEY);
        if (selectingNextAbility) {
            Destroy(activeAbility.gameObject);
            abilities.CycleAbility();
            activeAbility = Instantiate(abilities.GetActiveAbility(), gameObject.transform); ;
        }
    }

    private void UpdateMidair() {
        isTouchingGround = mainCharacterFeetCollider.IsTouchingLayers(LayerMask.GetMask(GameKeys.LAYER_GROUND_KEY));
        if (isTouchingGround) {
            hasReversedInMidair = false;
        }
    }

    private IEnumerator DelayAttack() {
        yield return new WaitForSeconds(GetGameStatByKey("MOVEMENT_ATTACK_SPEED").GetCurrentValue());
        canAttack = true;
    }

    public void Die() {
        if (GetGameStatByKey("LIFE").GetCurrentValue() > 0) return;

        FindObjectOfType<GameSession>().ProcessPlayerDeath(GetComponentInParent<MainCharacter>());
        DeathBehavior[] deathBehaviors = GetComponents<DeathBehavior>();
        foreach (DeathBehavior deathBehavior in deathBehaviors) {
            deathBehavior.OnDeath();
        }
    }
}
