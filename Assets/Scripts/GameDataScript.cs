using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataScript
{
    //Player stats
    public float spawnX;
    public float spawnY;
    public float spawnZ;
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
    public int[] items;
    public int[] storedItems;
    public int changingScene;
    public bool movLeft;
    public bool movRight;
    public bool movUp;
    public bool movDown;
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
    public int availableGems;
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
    public int knight;
    public int firstAttackObjective;
    public int playerAttackFirst;
    public int playerAttack;
    public int playerStyle;
    public int companionAttack;
    public int companionStyle;
    //Flags
    public int clearJail;

    //Contructor to use when saving the game
    public GameDataScript (CurrentDataScript current)
    {
        spawnX = current.spawnX;
        spawnY = current.spawnY;
        spawnZ = current.spawnZ;
        playerCurrentHealth = current.playerCurrentHealth;
        playerCurrentLight = current.playerCurrentLight;
        souls = current.souls;
        playerLvl = current.playerLvl;
        playerHeartLvl = current.playerHeartLvl;
        playerLightLvl = current.playerLightLvl;
        playerBadgeLvl = current.playerBadgeLvl;
        lvlExp = current.lvlExp;
        currentCoins = current.currentCoins;
        spentGP = current.spentGP;
        swordLvl = current.swordLvl;
        shurikenLvl = current.shurikenLvl;
        items = current.items;
        storedItems = current.storedItems;
        changingScene = current.changingScene;
        movLeft = current.movLeft;
        movRight = current.movRight;
        movUp = current.movUp;
        movDown = current.movDown;
        currentCompanion = current.currentCompanion;
        unlockedCompanions = current.unlockedCompanions;
        adventurerCurrentHealth = current.adventurerCurrentHealth;
        wizardCurrentHealth = current.wizardCurrentHealth;
        adventurerLvl = current.adventurerLvl;
        wizardLvl = current.wizardLvl;
        lightSword = current.lightSword;
        multistrikeSword = current.multistrikeSword;
        lightShuriken = current.lightShuriken;
        fireShuriken = current.fireShuriken;
        HPUp = current.HPUp;
        LPUp = current.LPUp;
        compHPUp = current.compHPUp;
        lightSwordFound = current.lightSwordFound;
        multistrikeSwordFound = current.multistrikeSwordFound;
        lightShurikenFound = current.lightShurikenFound;
        fireShurikenFound = current.fireShurikenFound;
        HPUpFound = current.HPUpFound;
        LPUpFound = current.LPUpFound;
        compHPUpFound = current.compHPUpFound;
        availableGems = current.availableGems;
        swordStyles = current.swordStyles;
        shurikenStyles = current.shurikenStyles;
        master = current.master;
        music = current.music;
        effects = current.effects;
        fullScreen = current.fullScreen;
        resolutionX = current.resolutionX;
        resolutionY = current.resolutionY;
        language = current.language;
        fled = current.fled;
        playerFirstAttack = current.playerFirstAttack;
        companionFirstAttack = current.companionFirstAttack;
        enemyStart = current.enemyStart;
        enemyDied = current.enemyDied;
        battle = current.battle;
        enemy1 = current.enemy1;
        enemy2 = current.enemy2;
        enemy3 = current.enemy3;
        enemy4 = current.enemy4;
        first = current.first;
        bandit = current.bandit;
        wizard = current.wizard;
        king = current.king;
        knight = current.knight;
        firstAttackObjective = current.firstAttackObjective;
        playerAttackFirst = current.playerAttackFirst;
        playerAttack = current.playerAttack;
        playerStyle = current.playerStyle;
        companionAttack = current.companionAttack;
        companionStyle = current.companionStyle;
        clearJail = current.clearJail;
    }

}
