using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : GameStat
{
    [Header("Model")]
    [SerializeField] GameObject healthOwner;

    private bool isDead = false;

    DeathBehavior[] deathBehaviors;

    DebugOptions debugOptions;

    private void Start() {
        deathBehaviors = GetComponents<DeathBehavior>();
        debugOptions = FindObjectOfType<DebugOptions>();
        if (GetComponent<MainCharacter>()) {
            maxValue = FindObjectOfType<GameSession>().currentMaximumHealth;
        }
        currentValue = maxValue;
    }

    private void Update() {
        if (isDead && ReadyToDie()) {
            Destroy(healthOwner);
        }
    }

    private bool ReadyToDie() {
        foreach (DeathBehavior deathBehavior in deathBehaviors) {
            if (!deathBehavior.isCompleted) {
                return false;
            }
        }
        return true;
    }

    public void AddHealth(float healthToAdd) {
        CurrentHealth = (CurrentHealth + healthToAdd > MaximumHealth) ? MaximumHealth : CurrentHealth + healthToAdd;
    }

    public void RemoveHealth(float healthToRemove) {
        bool isGodmodedMainCharacter = GetComponentInParent<MainCharacter>() && debugOptions.godMode;
        if (healthToRemove < 0 || isGodmodedMainCharacter) { return; }

        CurrentHealth = (CurrentHealth < healthToRemove) ? 0 : CurrentHealth - healthToRemove;
        
        if (CurrentHealth == 0) {
            Die();
        }
    }

    public float GetMissingHealth() {
        return MaximumHealth - CurrentHealth;
    }

    private void Die() {
        isDead = true;
        FindObjectOfType<GameSession>().ProcessPlayerDeath(GetComponentInParent<MainCharacter>());
        DeathBehavior[] deathBehaviors = GetComponents<DeathBehavior>();
        foreach (DeathBehavior deathBehavior in deathBehaviors) {
            deathBehavior.OnDeath();
        }
    }
}
