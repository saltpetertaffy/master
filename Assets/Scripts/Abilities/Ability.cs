using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour 
{
    [SerializeField] EquippedAbilitySelection abilitySelectionIcon;
    private GameObject abilityPrefab;
    private string abilityId;

    public abstract void Activate();

    public void Select() {
        abilitySelectionIcon.SelectAbility();
    }

    public void Deselect() {
        abilitySelectionIcon.DeselectAbility();
    }

    public string GetAbilityId() {
        return abilityId;
    }

    public void SetAbilityId(string abilityId) {
        this.abilityId = abilityId;
    }

    public void SetAbilityPrefab(string path) {
        abilityPrefab = Resources.Load<GameObject>(path);
    }

    public GameObject GetAbilityPrefab() {
        return abilityPrefab;
    }
}
