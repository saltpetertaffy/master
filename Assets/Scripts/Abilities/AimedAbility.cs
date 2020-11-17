using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class AimedAbility : Ability
{
    protected Animator abilityAnimator;
    private Rotator rotator;

    public override void Initialize() {
        throw new System.NotImplementedException();
    }

    protected void Start()
    {
        abilityAnimator = GetComponent<Animator>();
        rotator = GetComponent<Rotator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotator) {
            rotator = GetComponent<Rotator>();
        }
        if (!abilityAnimator) {
            abilityAnimator = GetComponent<Animator>();
        }
        AimAbility();
    }

    private void AimAbility() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 weaponPos = transform.position;

        float angle = Mathf.Atan2(mousePos.y - weaponPos.y, mousePos.x - weaponPos.x) * Mathf.Rad2Deg;
        rotator.RotateInstant(angle);
    }

    public override void Activate() {
        abilityAnimator.SetTrigger(GameKeys.ANMIMATION_ACTIVATED_TRIGGER);
    }

    protected float GetAimingAngle() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 weaponPos = transform.position;

        float angle = Mathf.Atan2(mousePos.y - weaponPos.y, mousePos.x - weaponPos.x) * Mathf.Rad2Deg;

        return angle;
    }
}
