using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CurrentDataScript : MonoBehaviour
{
    //Player stats
    public int playerCurrentHealth;
    public int playerCurrentLight;
    public int souls;
    public int playerLvl;
    public int playerHeartLvl;
    public int playerLightLvl;
    public int playerBadgeLvl;
    public int lvlExp;
    public int currentCoins;
    public int spentGP;
    public int swordLvl;
    public int shurikenLvl;
    public int[] items = { 2, 1, 1, 2, 3, 1, 1, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    //Companion stats
    public int currentCompanion;
    public int unlockedCompanions;
    public int adventurerCurrentHealth;
    public int wizardCurrentHealth;
    public int adventurerLvl;
    public int wizardLvl;
    //Gems
    public int lightSword;
    public int multistrikeSword;
    public int lightShuriken;
    public int fireShuriken;
    public int HPUp;
    public int LPUp;
    public int compHPUp;
    public int lightSwordFound;
    public int multistrikeSwordFound;
    public int lightShurikenFound;
    public int fireShurikenFound;
    public int HPUpFound;
    public int LPUpFound;
    public int compHPUpFound;
    //Available attacks
    public int swordStyles;
    public int shurikenStyles;
    //Settings
    public float master;
    public float music;
    public float effects;
    public int fullScreen;
    public int resolutionX;
    public int resolutionY;
    public int language;
    //Battle
    public int fled;
    public int playerFirstAttack;
    public int companionFirstAttack;
    public int enemyStart;
    public int enemyDied;
    public int battle;
    public int enemy1;
    public int enemy2;
    public int enemy3;
    public int enemy4;
    public int first;
    public int bandit;
    public int wizard;
    public int king;
    public int firstAttackObjective;
    public int playerAttackFirst;
    public int playerAttack;
    public int playerStyle;
    public int companionAttack;
    public int companionStyle;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //Function to know if a gem has been found
    public int GemFound(string g, string[] allGems)
    {
        if ((allGems[0] + " Found") == g)
        {
            return lightSwordFound;
        }
        else if ((allGems[1] + " Found") == g)
        {
            return multistrikeSwordFound;
        }
        else if ((allGems[2] + " Found") == g)
        {
            return lightShurikenFound;
        }
        else if ((allGems[3] + " Found") == g)
        {
            return fireShurikenFound;
        }
        else if ((allGems[4] + " Found") == g)
        {
            return HPUpFound;
        }
        else if ((allGems[5] + " Found") == g)
        {
            return LPUpFound;
        }
        else
        {
            return compHPUpFound;
        }
    }

    //Function to know if a gem is in use
    public int GemUsing(string g, string[] allGems)
    {
        if ((allGems[0]) == g)
        {
            return lightSword;
        }
        else if ((allGems[1]) == g)
        {
            return multistrikeSword;
        }
        else if ((allGems[2]) == g)
        {
            return lightShuriken;
        }
        else if ((allGems[3]) == g)
        {
            return fireShuriken;
        }
        else if ((allGems[4]) == g)
        {
            return HPUp;
        }
        else if ((allGems[5]) == g)
        {
            return LPUp;
        }
        else
        {
            return compHPUp;
        }
    }

    //Function to activate a gem
    public void SetGemUsing(string g, string[] allGems, int active)
    {
        if ((allGems[0]) == g)
        {
            lightSword = active;
        }
        else if ((allGems[1]) == g)
        {
            multistrikeSword = active;
        }
        else if ((allGems[2]) == g)
        {
            lightShuriken = active;
        }
        else if ((allGems[3]) == g)
        {
            fireShuriken = active;
        }
        else if ((allGems[4]) == g)
        {
            HPUp = active;
        }
        else if ((allGems[5]) == g)
        {
            LPUp = active;
        }
        else
        {
            compHPUp = active;
        }
    }

    //Function to load the data
    public void LoadData(GameDataScript data)
    {
        playerCurrentHealth = data.playerCurrentHealth;
        playerCurrentLight = data.playerCurrentLight;
        souls = data.souls;
        playerLvl = data.playerLvl;
        playerHeartLvl = data.playerHeartLvl;
        playerLightLvl = data.playerLightLvl;
        playerBadgeLvl = data.playerBadgeLvl;
        lvlExp = data.lvlExp;
        currentCoins = data.currentCoins;
        spentGP = data.spentGP;
        swordLvl = data.swordLvl;
        shurikenLvl = data.shurikenLvl;
        items = data.items;
        currentCompanion = data.currentCompanion;
        unlockedCompanions = data.unlockedCompanions;
        adventurerCurrentHealth = data.adventurerCurrentHealth;
        wizardCurrentHealth = data.wizardCurrentHealth;
        adventurerLvl = data.adventurerLvl;
        wizardLvl = data.wizardLvl;
        lightSword = data.lightSword;
        multistrikeSword = data.multistrikeSword;
        lightShuriken = data.lightShuriken;
        fireShuriken = data.fireShuriken;
        HPUp = data.HPUp;
        LPUp = data.LPUp;
        compHPUp = data.compHPUp;
        lightSwordFound = data.lightSwordFound;
        multistrikeSwordFound = data.multistrikeSwordFound;
        lightShurikenFound = data.lightShurikenFound;
        fireShurikenFound = data.fireShurikenFound;
        HPUpFound = data.HPUpFound;
        LPUpFound = data.LPUpFound;
        compHPUpFound = data.compHPUpFound;
        swordStyles = data.swordStyles;
        shurikenStyles = data.shurikenStyles;
        master = data.master;
        music = data.music;
        effects = data.effects;
        fullScreen = data.fullScreen;
        resolutionX = data.resolutionX;
        resolutionY = data.resolutionY;
        language = data.language;
        fled = data.fled;
        playerFirstAttack = data.playerFirstAttack;
        companionFirstAttack = data.companionFirstAttack;
        enemyStart = data.enemyStart;
        enemyDied = data.enemyDied;
        battle = data.battle;
        enemy1 = data.enemy1;
        enemy2 = data.enemy2;
        enemy3 = data.enemy3;
        enemy4 = data.enemy4;
        first = data.first;
        bandit = data.bandit;
        wizard = data.wizard;
        king = data.king;
        firstAttackObjective = data.firstAttackObjective;
        playerAttackFirst = data.playerAttackFirst;
        playerAttack = data.playerAttack;
        playerStyle = data.playerStyle;
        companionAttack = data.companionAttack;
        companionStyle = data.companionStyle;
    }

}
