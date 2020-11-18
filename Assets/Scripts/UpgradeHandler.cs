using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    public void ApplyPermanentUpgrades(List<Upgrade> upgrades) {
        if (upgrades.Count == 0) { return; }

        List<GameStatEffect> setUpgradeEffects = new List<GameStatEffect>();
        List<GameStatEffect> addUpgradeEffects = new List<GameStatEffect>();
        List<GameStatEffect> multiplyUpgradeEffects = new List<GameStatEffect>();

        foreach (Upgrade upgrade in upgrades) {
            foreach (GameStatEffect effect in upgrade.Effects) {
                switch (effect.GetEffectType()) {
                    case (int) GameStatEffectTypes.SET:
                        setUpgradeEffects.Add(effect);
                        break;
                    case (int) GameStatEffectTypes.ADD:
                        addUpgradeEffects.Add(effect);
                        break;
                    case (int) GameStatEffectTypes.MULTIPLY:
                        multiplyUpgradeEffects.Add(effect);
                        break;
                    default:
                        throw new EffectNotFoundException("Effect type not found: " + effect.GetEffectType());
                }
            }
        }

        MainCharacter mainCharacter = FindObjectOfType<MainCharacter>();

        // enforce order of operations (set, add, multiply)
        foreach (GameStatEffect effect in setUpgradeEffects) {
            ApplyPermanentEffect(mainCharacter, effect);    
        }
        foreach (GameStatEffect effect in addUpgradeEffects) {
            ApplyPermanentEffect(mainCharacter, effect);
        }
        foreach (GameStatEffect effect in multiplyUpgradeEffects) {
            ApplyPermanentEffect(mainCharacter, effect);
        }
    }

    private void ApplyPermanentEffect(MainCharacter mainCharacter, GameStatEffect effect) {
        GameStat stat;
        switch (effect.GetGameStatEffectCategory()) {
            //case GameStatEffectCategories.
        }
        switch (effect.GetEffectType()) {
            case (int) GameStatEffectTypes.SET:

                break;
            case (int) GameStatEffectTypes.ADD:

                break;
            case (int) GameStatEffectTypes.MULTIPLY:

                break;
        }
    }
}
