using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        targetLayer = GameKeys.LAYER_HITBOX_KEY;
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
                    totalDamage += Mathf.RoundToInt(projectileEffect.GetValue() * mainCharacterHealth.CurrentHealth);
                    break;
            }
        }
        totalDamage = (int) (totalDamage * (1 - mainCharacterArmor.CurrentArmor / 100) - mainCharacterArmor.FreeArmor);

        Color projectileColor;
        if (mainCharacterHealth.CurrentHealth == 0) {
            projectileColor = Color.red;
        }
        else if (totalDamage > 0) {
            float damageRedShade = totalDamage / mainCharacterHealth.CurrentHealth;
            projectileColor = new Color(1, 1 - damageRedShade, 1 - damageRedShade);
        }
        else if (totalDamage < 0) {
            float healingCyanShade = Mathf.Abs(totalDamage) / mainCharacterHealth.CurrentHealth;
            projectileColor = new Color(0, 1 - healingCyanShade, 1);
        }
        else {
            projectileColor = Color.white;
        }
            return projectileColor;
    }
}
