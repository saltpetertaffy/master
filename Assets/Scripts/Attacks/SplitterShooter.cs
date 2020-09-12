using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterShooter : MainCharacterShooter
{
    public override void Activate() {
        MakeSplitterProjectile();
        SplitterProjectile secondShot = MakeSplitterProjectile();
        secondShot.IsReversed(true);
    }

    private SplitterProjectile MakeSplitterProjectile() {
        abilityAnimator.SetTrigger(GameKeys.ANMIMATION_ACTIVATED_TRIGGER);
        float aimingAngle = GetAimingAngle();
        MainCharacterProjectile newProjectile = Instantiate(projectile,
            attackPoint.transform.position,
            Quaternion.Euler(0, 0, aimingAngle - 90)
            );
        newProjectile.SetStartingAngle(aimingAngle);
        newProjectile.SetSpeed(projectileSpeed);
        return newProjectile as SplitterProjectile;
    }
}
