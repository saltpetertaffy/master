using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class Hitbox : MonoBehaviour
{
    Health health;

    private void Start() {
        health = GetComponent<Health>();
    }

    public void HandleHit(GameStatEffect[] projectileEffects) {
        HandleDamage(projectileEffects);
        HandleArmor();
    }

    private void HandleDamage(GameStatEffect[] projectileEffects) {
        int totalDamage = 0;

        foreach (GameStatEffect projectileEffect in projectileEffects) {
            switch (projectileEffect.GetGameStatEffectId()) {
                case (int) GameStatEffects.DAMAGE:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue());
                    break;
                case (int) GameStatEffects.DAMAGE_PERCENT_MAX:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * health.GetMaximumHealth());
                    break;
                case (int) GameStatEffects.DAMAGE_PERCENT_REMAINING:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * health.GetHealth());
                    break;
            }
        }

        totalDamage = (int) (totalDamage * (1 - health.GetArmor() / 100));

        health.RemoveHealth(totalDamage);
    }

    private void HandleArmor() {
        ArmorAbsorber absorber = GetComponentInParent<ArmorAbsorber>();
        if (absorber) {
            health.AddArmor(absorber.GetOnHitArmorRestoreAmount());
        }
    }
}
