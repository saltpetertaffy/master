using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatProperty : MonoBehaviour
{
    private int gameStatPropertyId;
    private string gameStatPropertyName;
    private float gameStatPropertyValue;

    public void setGameStatPropertyId(int id){
        gameStatPropertyId = id;
    }
    public void setGameStatPropertyName(string name) {
        gameStatPropertyName = name;
    }
    public void setGameStatPropertyValue(float value) {
        gameStatPropertyValue = value;
    }

    public int getGameStatPropertyId() {
        return gameStatPropertyId;
    }
    public string getGameStatPropertyName() {
        return gameStatPropertyName;
    }

    public float getGameStatPropertyValue() {
        return gameStatPropertyValue;
    }
}
