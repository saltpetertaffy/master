using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedAbilitySelector : MonoBehaviour
{
    [SerializeField] EquippedAbilitySelection[] abilities;

    private int activeAbilityIndex = 0;

    public void CycleAbility() {
        if (activeAbilityIndex == abilities.Length - 1 || !abilities[activeAbilityIndex + 1].GetAbility()) {
            activeAbilityIndex = 0;
        } else {
            activeAbilityIndex++;
        }

        SelectAbility(activeAbilityIndex);
    }

    public void SelectAbility(int selectedAbilityIndex) {
        for (int i = 0; i < abilities.Length; i++) {
            if (i == selectedAbilityIndex) {
                abilities[i].SelectAbility();
            } else {
                abilities[i].DeselectAbility();
            }
        }
    }

    public Ability GetActiveAbility() {
        return abilities[activeAbilityIndex].GetAbility();
    }
}
