using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

public class EquippedAbilitySelector : MonoBehaviour
{
    List<EquippedAbilitySelection> abilities = new List<EquippedAbilitySelection>();

    private int activeAbilityIndex = 0;

    private const string EQUIPPED_ABILITY_SELECTION_RELATIVE_PATH = "Prefabs/UI/";
    private const string EQUIPPED_ABILITY_SELECTION_FILE_NAME = "Equipped Ability Selection";
    private const float EQUIPPED_ABILITY_SELECTION_OFFSET = -390f;
    private const float EQUIPPED_ABILITY_SELECTION_SPACING = 100f;
    private const float EQUIPPED_ABILITY_SELECTION_SCALE_ALL_AXES = 1f;

    public Ability CycleAbility() {
        if (activeAbilityIndex == abilities.Count - 1 || abilities[activeAbilityIndex + 1] == null) {
            activeAbilityIndex = 0;
        } else {
            activeAbilityIndex++;
        }

        SelectAbility(activeAbilityIndex);
        return abilities[activeAbilityIndex].GetAbility();
    }

    public void SelectAbility(int selectedAbilityIndex) {
        for (int i = 0; i < abilities.Count; i++) {
            if (i == selectedAbilityIndex) {
                abilities[i].SelectAbility();
                activeAbilityIndex = i;
            } else {
                abilities[i].DeselectAbility();
            }
        }
    }

    public Ability GetActiveAbility() {
        return abilities[activeAbilityIndex].GetAbility();
    }

    public void addAbility(Ability ability) {
        GameObject selectionPrefab = Instantiate(
            Resources.Load(EQUIPPED_ABILITY_SELECTION_RELATIVE_PATH + EQUIPPED_ABILITY_SELECTION_FILE_NAME) as GameObject);
        GameObject selectionSpritePrefab = Instantiate(
            Resources.Load(EQUIPPED_ABILITY_SELECTION_RELATIVE_PATH + ability.AbilityId) as GameObject,
            selectionPrefab.transform);
        EquippedAbilitySelection selection = selectionPrefab.GetComponent<EquippedAbilitySelection>();
        selection.Initialize();
        SpriteRenderer selectionSprite = selectionSpritePrefab.GetComponent<SpriteRenderer>();
        selection.SetAbility(ability);
        selection.SetSelectionSprite(selectionSprite);
        RectTransform selectionRectTransform = selection.GetComponent<RectTransform>();
        selectionRectTransform.SetParent(gameObject.transform);
        selectionRectTransform.localPosition = new Vector2(EQUIPPED_ABILITY_SELECTION_OFFSET 
            + (EQUIPPED_ABILITY_SELECTION_SPACING * abilities.Count), 0);
        selectionRectTransform.localScale = new Vector3(EQUIPPED_ABILITY_SELECTION_SCALE_ALL_AXES, 
            EQUIPPED_ABILITY_SELECTION_SCALE_ALL_AXES, 
            EQUIPPED_ABILITY_SELECTION_SCALE_ALL_AXES);
        abilities.Add(selection);
    }

    public void ClearAbilities() {
        abilities.Clear();
    }
}
