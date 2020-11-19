using System.Collections;
using UnityEngine;
using GameConstants;
using System.Dynamic;

public class MainCharacter : MonoBehaviour {
    public float MoveSpeed { get; set; }
    public float JumpSpeed { get; set; }
    public float AttackSpeed { get; set; }
    public float MidairReverseSpeed { get; set; }

    Ability activeAbility { get; set; }
    BoxCollider2D mainCharacterFeetCollider;
    Rigidbody2D mainCharacterRigidbody;
    EquippedAbilitySelector abilities;

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
            selectedSpeed = MidairReverseSpeed;
            hasReversedInMidair = true;
        } else {
            selectedSpeed = MoveSpeed;
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

        Vector2 newVelocity = new Vector2(mainCharacterRigidbody.velocity.x, JumpSpeed);
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
        yield return new WaitForSeconds(AttackSpeed);
        canAttack = true;
    }
}
