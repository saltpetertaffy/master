using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class AimedAbility : Ability
{
    private Animator weaponAnimator;
    private Rotator rotator;

    // Start is called before the first frame update
    void Start()
    {
        weaponAnimator = GetComponent<Animator>();
        rotator = GetComponent<Rotator>();
    }

    // Update is called once per frame
    void Update()
    {
        AimAbility();
    }

    private void AimAbility() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 weaponPos = transform.position;

        float angle = Mathf.Atan2(mousePos.y - weaponPos.y, mousePos.x - weaponPos.x) * Mathf.Rad2Deg;
        rotator.RotateInstant(angle);
    }

    public override void Activate() {
        weaponAnimator.SetTrigger(GameKeys.ANMIMATION_ACTIVATED_TRIGGER);
    }
}
