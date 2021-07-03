using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public string characterId;

    List<GameStat> gameStats;
    CharacterLoader characterLoader;

    private void Awake() {
        characterLoader = GetComponent<CharacterLoader>();
        characterLoader.LoadCharacter(characterId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
