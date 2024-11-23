using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUp : MonoBehaviour
{
    public int level = 1;
    public float experience { get; private set; }
    public TextMeshProUGUI lvlText;
    public Image xpBarImage;
    [SerializeField] GameObject canvas;
    bool levelChanged;

    public static int ExpNeedTolvlUp(int currentLevel)
    {
        return (currentLevel * currentLevel + currentLevel) * 5;   
    }
     void Update()
    {
        if (levelChanged)
        {
            PowerUPMenu script = canvas.GetComponent<PowerUPMenu>();
            script.PowerUpMenu();
            levelChanged = false;
        }
        
    }
    public void SetExperience(float exp)
    {
        experience += exp;
        float expNeeded = ExpNeedTolvlUp(level);
        float previousExperience = ExpNeedTolvlUp(level - 1);
        if(experience >= expNeeded)
        {
            LevelSetting();
            expNeeded = ExpNeedTolvlUp(level);
            previousExperience = ExpNeedTolvlUp(level - 1);
        }
        xpBarImage.fillAmount = (experience - previousExperience) / (expNeeded - previousExperience);
        if (xpBarImage.fillAmount == 1)
        {
            xpBarImage.fillAmount = 0;
        }
    }
    public void LevelSetting()
    {
        levelChanged = true;
        level++;
        lvlText.text = level.ToString("");
    }
}
