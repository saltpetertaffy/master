﻿using Cinemachine;
using GameConstants;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] float levelResetWaitTime = 3f;
    [SerializeField] public int lives = 3;
    public int currentMaximumHealth = 100;
    public int currentMaximumArmor = 50;

    SceneLoader sceneLoader;

    private const string ABILITIES_RELATIVE_PATH = "Prefabs/Abilities/";
    
    private void Awake() {
        if (FindObjectsOfType<GameSession>().Length > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
        if (SceneManager.GetActiveScene().buildIndex != 0) {
            LoadGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    public void ProcessPlayerDeath(MainCharacter mainCharacter) {
        if (mainCharacter) {
            FindObjectOfType<CinemachineStateDrivenCamera>().enabled = false;
            lives--;
            StartCoroutine(DelayedResetLevel(levelResetWaitTime));
        }
    }

    public void SaveGame() {
        Save save = CreateSave();

        BinaryFormatter bin = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save1.save");
        bin.Serialize(file, save);
        file.Close();
    }

    private Save CreateSave() {
        Save save = new Save();
        save.lives = lives;

        return save;
    }

    public void ResetLevel() {
        SaveGame();
        sceneLoader.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator DelayedResetLevel(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        ResetLevel();
    }

    public void LoadGame() {
        if (File.Exists(Application.persistentDataPath + "/save1.save")) {
            BinaryFormatter bin = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save1.save", FileMode.Open);
            Save save = (Save) bin.Deserialize(file);
            file.Close();

            lives = save.lives;

            SetAbilityLoadout(save.abilityLoadout);

            Debug.Log("Game Loaded");
        } else {
            Debug.Log("No saved games.");
        }
    }

    private void SetAbilityLoadout(string[] abilityLoadout) {
        EquippedAbilitySelector abilitySet = FindObjectOfType<EquippedAbilitySelector>();
        abilitySet.ClearAbilities();
        foreach (string abilityKey in abilityLoadout) {
            if (abilityKey != null) {
                GameObject abilityPrefab = Instantiate(Resources.Load(ABILITIES_RELATIVE_PATH + abilityKey) as GameObject);
                Ability ability;
                switch (abilityKey) {
                    case GameKeys.ABILITY_SPARK_KEY:
                        ability = abilityPrefab.GetComponent<Spark>();
                        break;
                    case GameKeys.ABILITY_SPLITTER_KEY:
                        ability = abilityPrefab.GetComponent<Splitter>();
                        break;
                    default:
                        throw new AbilityNotFoundException("Ability " + abilityKey + " not found.");
                }
                ability.Initialize();
                abilitySet.addAbility(ability);
            } else {
                Debug.LogError("Ability not found.");
                throw new AbilityNotFoundException("Ability not found.");
            }
        }
    }

    public void StartGame() {
        Save save = new Save();

        BinaryFormatter bin = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save1.save");
        bin.Serialize(file, save);
        file.Close();

        sceneLoader.LoadNextScene();
    }
}
