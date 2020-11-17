using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;
using UnityEngine.UI;

public class EquippedAbilitySelection : MonoBehaviour
{
    private SpriteRenderer selectionSprite;
    private Ability ability;
    private Image selectionImage;

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

    public void SetSelectionSprite(SpriteRenderer selectionSprite) {
        this.selectionSprite = selectionSprite;
    }

    public SpriteRenderer GetSelectionSprite() {
        return selectionSprite;
    }
}
