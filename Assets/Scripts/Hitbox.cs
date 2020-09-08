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
                case GameConfigConstants.EFFECT_ID_DAMAGE:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue());
                    break;
                case GameConfigConstants.EFFECT_ID_DAMAGE_PERCENT_MAX:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * health.GetMaximumHealth());
                    break;
                case GameConfigConstants.EFFECT_ID_DAMAGE_PERCENT_REMAINING:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * health.GetHealth());
                    break;
            }
        }

        health.RemoveHealth(totalDamage);
    }
}
