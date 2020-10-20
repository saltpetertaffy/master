using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class EquippedItemSelection : MonoBehaviour
{
    private SpriteRenderer selectionSprite;

    public void Start() {
        selectionSprite = GetComponent<SpriteRenderer>();
    }

    public void SelectEquip() {
        Color selectionColor = selectionSprite.color;
        selectionColor.a = GameConfigConstants.UI_EQUIP_SELECTED_ALPHA;
        selectionSprite.color = selectionColor;
    }

    public void DeselectEquip() {
        Color selectionColor = selectionSprite.color;
        selectionColor.a = 0f;
        selectionSprite.color = selectionColor;
    }
}
