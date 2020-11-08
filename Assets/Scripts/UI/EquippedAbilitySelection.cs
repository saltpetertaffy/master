using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class EquippedAbilitySelection : MonoBehaviour
{
    private SpriteRenderer selectionSprite;
    private Ability ability;

    public void Start() {
        selectionSprite = GetComponent<SpriteRenderer>();
    }

    public void SelectAbility() {
        Color selectionColor = selectionSprite.color;
        selectionColor.a = GameConfigConstants.UI_EQUIP_SELECTED_ALPHA;
        selectionSprite.color = selectionColor;
    }

    public void DeselectAbility() {
        Color selectionColor = selectionSprite.color;
        selectionColor.a = 0f;
        selectionSprite.color = selectionColor;
    }

    public void SetAbility(Ability ability) {
        this.ability = ability;
    }

    public Ability GetAbility() {
        return ability;
    }
}
