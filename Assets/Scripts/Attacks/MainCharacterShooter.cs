using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterShooter : AimedAbility
{
    [SerializeField] MainCharacterProjectile projectile;
    [SerializeField] GameObject attackPoint;
    [SerializeField] float projectileSpeed;

    public override void Activate() {
        abilityAnimator.SetTrigger(GameKeys.ANMIMATION_ACTIVATED_TRIGGER);
        float aimingAngle = GetAimingAngle();
        MainCharacterProjectile newProjectile = Instantiate(projectile, 
            attackPoint.transform.position, 
            Quaternion.Euler(0, 0, aimingAngle - 90)
            );
        newProjectile.SetStartingAngle(aimingAngle);
        newProjectile.SetSpeed(projectileSpeed);
    }
}
