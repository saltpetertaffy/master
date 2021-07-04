using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public string characterId;

    List<KeyValuePair<string, GameStat>> gameStats;
    CharacterLoader characterLoader;

    private void Awake() {
        characterLoader = GetComponent<CharacterLoader>();
        gameStats = characterLoader.LoadCharacter(characterId);
    }

    public List<KeyValuePair<string, GameStat>> GetGameStats() {
        return gameStats;
    }

    protected GameStat GetGameStatByKey(string key) {
        return gameStats.SingleOrDefault(j => j.Key == "MOVEMENT_MIDAIR_REVERSE_SPEED").Value;
    }
}
