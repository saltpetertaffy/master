using System.Collections;
using UnityEngine;
using GameConstants;
using System.Dynamic;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;

public class MainCharacter : MonoBehaviour {
    public float MoveSpeed { get; set; }
    public float JumpSpeed { get; set; }
    public float AttackSpeed { get; set; }
    public float MidairReverseSpeed { get; set; }

    Ability activeAbility { get; set; }
    BoxCollider2D mainCharacterFeetCollider;
    Rigidbody2D mainCharacterRigidbody;
    EquippedAbilitySelector abilities;
    UpgradeHandler upgradeHandler;

    float jumpXSpeed = 0;
    bool hasReversedInMidair = false;
    bool isTouchingGround = true;
    bool canAttack = true;

    private void Awake() {
        upgradeHandler = GetComponent<UpgradeHandler>();
        LoadMainCharacter();
    }

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

    private void LoadMainCharacter() {
        List<string> upgradeIds = new List<string>();
        string upgradesFilepath = Directory.GetCurrentDirectory() + "\\Main Character\\Main Character.xml";

        XDocument upgrades = XDocument.Load(upgradesFilepath);
        if (upgrades != null && upgrades.Descendants("MainCharacter") != null) {
            upgradeIds = upgrades.Descendants("UpgradeId")
                                 .Select(j => j.Attribute("id").Value)
                                 .ToList();
        }
        upgradeHandler.LoadUpgrades(upgradeIds);
        Health health = GetComponent<Health>();
        health.CurrentHealth = health.MaximumHealth;
        Armor armor = GetComponent<Armor>();
        armor.CurrentArmor = armor.MaximumArmor;
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
