using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour 
{
    private string abilityId;

    public abstract void Activate();

    public abstract void Initialize();

    public string GetAbilityId() {
        return abilityId;
    }

    public void SetAbilityId(string abilityId) {
        this.abilityId = abilityId;
    }
}
