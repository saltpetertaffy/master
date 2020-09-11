using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;
using System;

public class GameStatHandler : MonoBehaviour
{
    TextEmitter textEmitter = null;
    Health health = null;
    Armor armor = null;

    private void Awake() {
        textEmitter = FindObjectOfType<TextEmitter>();
        health = GetComponent<Health>();
        armor = GetComponent<Armor>();
    }

    public void ProcessEffects(GameStatEffect[] gameStatEffects) {     
        if (health) {
            HandleHealthEffects(gameStatEffects);
        }
        if (armor) {
            HandleArmorEffects(gameStatEffects);
        }
    }

    private void HandleHealthEffects(GameStatEffect[] gameStatEffects) {
        int totalDamage = 0;
        int totalHealing = 0;

        foreach (GameStatEffect gameStatEffect in gameStatEffects) {
            switch (gameStatEffect.GetGameStatEffectId()) {
                case (int) GameStatEffects.DAMAGE:
                    totalDamage += Mathf.RoundToInt(gameStatEffect.GetValue());
                    break;
                case (int) GameStatEffects.DAMAGE_PERCENT_MAX:
                    totalDamage += Mathf.RoundToInt(gameStatEffect.GetValue() * health.GetMaximumHealth());
                    break;
                case (int) GameStatEffects.DAMAGE_PERCENT_REMAINING:
                    totalDamage += Mathf.RoundToInt(gameStatEffect.GetValue() * health.GetHealth());
                    break;
            }
        }

        totalDamage = armor ? (int) (totalDamage * (1 - armor.GetArmor() / 100)) - armor.GetFreeArmor() : totalDamage;
        if (totalDamage > 0) {
            health.RemoveHealth(totalDamage);
            textEmitter.EmitText(totalDamage.ToString(), transform, Color.red);
        } else {
            totalHealing -= totalDamage;
        }
        if (totalHealing > 0) {
            health.AddHealth(totalHealing);
        }
    }

    private void HandleArmorEffects(GameStatEffect[] gameStatEffects) {
        armor.AddArmor(armor.GetArmorAbsoprtion());
    }
}
