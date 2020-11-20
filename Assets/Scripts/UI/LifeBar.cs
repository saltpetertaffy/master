using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : StatBar
{
    Health mainCharacterHealth;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacterHealth = FindObjectOfType<MainCharacter>().GetComponentInChildren<Health>();    
    }

    private void Update() {
        SetMaxStat(mainCharacterHealth.MaximumHealth);
        SetStat(mainCharacterHealth.CurrentHealth);
    }
}
