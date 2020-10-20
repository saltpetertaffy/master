using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour 
{
    [SerializeField] EquippedItemSelection abilitySelectionIcon;

    public abstract void Activate();

    public void Select() {
        abilitySelectionIcon.SelectEquip();
    }

    public void Deselect() {
        abilitySelectionIcon.DeselectEquip();
    }
}
