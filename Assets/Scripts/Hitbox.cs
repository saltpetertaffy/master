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

        health.RemoveHealth(totalDamage);
    }
}
