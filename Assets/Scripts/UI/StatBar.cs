using GameConstants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatBar : MonoBehaviour
{
    [SerializeField] GameObject statBarForeground;

    SpriteRenderer statBarBackgroundSprite;
    
    // Start is called before the first frame update
    void Awake()
    {
        statBarBackgroundSprite = GetComponent<SpriteRenderer>();
    }

    protected void SetStat(float statToSet) {
        float statBarForegroundWidth = statToSet * GameConfigConstants.UI_STAT_BAR_SCALING_MULTIPLIER
            - GameConfigConstants.UI_STAT_BAR_RIGHT_MARGIN;
        statBarForegroundWidth = statBarForegroundWidth >= 0 ? statBarForegroundWidth : 0;
        float statBarForegroundHeight = statBarForeground.GetComponent<SpriteRenderer>().size.y;

        statBarForeground.GetComponent<SpriteRenderer>().size = new Vector2(statBarForegroundWidth, statBarForegroundHeight);
    }

    protected void SetMaxStat(float maxStatToSet) {
        float statBarWidth = maxStatToSet * GameConfigConstants.UI_STAT_BAR_SCALING_MULTIPLIER;
        statBarBackgroundSprite.size = new Vector2(statBarWidth, statBarBackgroundSprite.size.y);
    }
}
