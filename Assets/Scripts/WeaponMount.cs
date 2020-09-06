using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class WeaponMount : MonoBehaviour
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
        AimWeapon();
    }

    private void AimWeapon() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 weaponPos = transform.position;

        float angle = Mathf.Atan2(mousePos.y - weaponPos.y, mousePos.x - weaponPos.x) * Mathf.Rad2Deg;
        rotator.RotateInstant(angle);
    }

    public void Fire() {
        weaponAnimator.SetTrigger(GameKeys.ANMIMATION_ATTACK_TRIGGER);
    }
}
