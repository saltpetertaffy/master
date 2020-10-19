using Cinemachine;
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
    
    private void Awake() {
        if (FindObjectsOfType<GameSession>().Length > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
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
        Debug.Log("Game saved.");
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

            Debug.Log("Game Loaded");
        } else {
            Debug.Log("No saved games.");
        }
    }
}
