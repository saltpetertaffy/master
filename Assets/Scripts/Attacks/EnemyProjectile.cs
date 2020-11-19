using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    Health mainCharacterHealth;
    Armor mainCharacterArmor;

    // Start is called before the first frame update
    void Start()
    {
        targetLayer = GameKeys.LAYER_HITBOX_KEY;
        mainCharacterHealth = FindObjectOfType<MainCharacter>().GetComponentInChildren<Health>();
        mainCharacterArmor = FindObjectOfType<MainCharacter>().GetComponentInChildren<Armor>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = GenerateProjectileColor();
    }

    private Color GenerateProjectileColor() {
        int totalDamage = 0;

        foreach (GameStatEffect projectileEffect in attackEffects) {
            switch (projectileEffect.GetGameStatEffectId()) {
                case (int) GameStatEffects.DAMAGE:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue());
                    break;
                case (int) GameStatEffects.DAMAGE_PERCENT_MAX:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * mainCharacterHealth.MaximumHealth);
                    break;
                case (int) GameStatEffects.DAMAGE_PERCENT_REMAINING:
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * mainCharacterHealth.GetHealth());
                    break;
            }
        }
        totalDamage = (int) (totalDamage * (1 - mainCharacterArmor.GetArmor() / 100) - mainCharacterArmor.GetFreeArmor());

        Color projectileColor;
        if (mainCharacterHealth.GetHealth() == 0) {
            projectileColor = Color.red;
        }
        else if (totalDamage > 0) {
            float damageRedShade = totalDamage / mainCharacterHealth.GetHealth();
            projectileColor = new Color(1, 1 - damageRedShade, 1 - damageRedShade);
        }
        else if (totalDamage < 0) {
            float healingCyanShade = Mathf.Abs(totalDamage) / mainCharacterHealth.GetHealth();
            projectileColor = new Color(0, 1 - healingCyanShade, 1);
        }
        else {
            projectileColor = Color.white;
        }
            return projectileColor;
    }
}
