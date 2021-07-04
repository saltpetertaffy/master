using UnityEngine;
using GameConstants;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class GameStatHandler : MonoBehaviour
{
    List<KeyValuePair<string, GameStat>> gameStats;

    public List<KeyValuePair<string, GameStat>> GetGameStats() {
        return gameStats;
    }

    public void SetGameStats(List<KeyValuePair<string, GameStat>> stats) {
        this.gameStats = stats;
    }

    public GameStat GetGameStatByKey(string key) {
        return gameStats.SingleOrDefault(j => j.Key == key).Value;
    }

    public void ModifyStat(StatEffect effect) {
        foreach (KeyValuePair<string, GameStat> statPair in gameStats) {
            GameStat stat = statPair.Value;
            if (stat.GetStatKey() == effect.gameStatKey) {
                switch (effect.effectType) {
                    case StatEffectTypes.SET:
                        stat.SetCurrentValue(effect.value);
                        return;
                    case StatEffectTypes.ADD:
                        stat.SetCurrentValue(stat.GetCurrentValue() + effect.value);
                        return;
                    case StatEffectTypes.MULTIPLY:
                        stat.SetCurrentValue(stat.GetCurrentValue() * effect.value);
                        return;
                    case StatEffectTypes.SET_DECAY_AMOUNT:
                        stat.SetDecayAmount(effect.value);
                        return;
                    case StatEffectTypes.ADD_DECAY_AMOUNT:
                        stat.SetDecayAmount(stat.GetDecayAmount() + effect.value);
                        return;
                    case StatEffectTypes.MULTIPLY_DECAY_AMOUNT:
                        stat.SetDecayAmount(stat.GetDecayAmount() * effect.value);
                        return;
                    case StatEffectTypes.SET_DECAY_RATE:
                        stat.SetDecayRate(effect.value);
                        return;
                    case StatEffectTypes.ADD_DECAY_RATE:
                        stat.SetDecayRate(stat.GetDecayRate() + effect.value);
                        return;
                    case StatEffectTypes.MULTIPLY_DECAY_RATE:
                        stat.SetDecayRate(stat.GetDecayRate() * effect.value);
                        return;
                    case StatEffectTypes.SET_ABSORPTION:
                        stat.SetAbsorption(effect.value);
                        return;
                    case StatEffectTypes.ADD_ABSORPTION:
                        stat.SetAbsorption(stat.GetAbsorption() + effect.value);
                        return;
                    case StatEffectTypes.MULTIPLY_ABSORPTION:
                        stat.SetAbsorption(stat.GetAbsorption() * effect.value);
                        return;
                }
            }
        }
    }
}
