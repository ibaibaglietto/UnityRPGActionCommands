﻿using System.Collections;
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
    //1-1
    public int clearJail;
    //1-2
    public int storageItem1;
    public int storageItem2;
    //1-3
    public int cityItem1;
    public int cityGem1;
    public int cityCoin1;
    public int cityCoin2;
    public int cityCoin3;
    public int cityCoin4;
    public int cityCoin5;
    public int cityCoin6;
    public int cityCoin7;
    public int cityCoin8;
    public int cityCoin9;
    public int cityCoin10;
    public int cityCoin11;
    public int cityCoin12;
    //1-4
    public int brokenBridgeItem1;
    public int brokenBridgeItem2;
    public int brokenBridgeCoin1;
    public int brokenBridgeCoin2;
    public int brokenBridgeCoin3;
    public int brokenBridgeCoin4;
    public int brokenBridgeCoin5;
    public int brokenBridgeCoin6;
    public int brokenBridgeCoin7;
    public int brokenBridgeCoin8;
    public int brokenBridgeCoin9;
    public int brokenBridgeCoin10;
    public int brokenBridgeCoin11;
    public int brokenBridgeCoin12;
    public int brokenBridgeCoin13;
    public int brokenBridgeCoin14;
    public int brokenBridgeCoin15;
    public int brokenBridgeCoin16;
    //1-5
    public int citySideItem1;
    public int citySideGem1;
    public int citySideCoin1;
    public int citySideCoin2;
    public int citySideCoin3;
    public int citySideCoin4;
    public int citySideCoin5;
    public int citySideCoin6;
    public int citySideCoin7;
    public int citySideCoin8;
    public int citySideCoin9;
    public int citySideCoin10;
    public int citySideCoin11;
    public int citySideCoin12;
    public int citySideCoin13;
    public int citySideCoin14;
    public int citySideCoin15;
    public int citySideCoin16;
    public int citySideCoin17;
    public int citySideCoin18;
    public int citySideCoin19;
    public int citySideCoin20;
    public int citySideCoin21;
    public int citySideCoin22;
    public int citySideCoin23;
    public int citySideCoin24;
    //1-6
    public int waterItem1;
    public int waterClear;
    //1-7
    public int bridge1Coin1;
    public int bridge1Coin2;
    public int bridge1Coin3;
    public int bridge1Coin4;
    public int bridge1Coin5;
    public int bridge1Coin6;
    public int bridge1Coin7;
    public int bridge1Coin8;
    public int bridge1Coin9;
    public int bridge1Coin10;
    public int bridge1Coin11;
    public int bridge1Coin12;
    public int bridge1Coin13;
    public int bridge1Coin14;
    public int bridge1Coin15;
    public int bridge1Coin16;
    public int bridge1Coin17;
    public int bridge1Coin18;
    public int bridge1Coin19;
    public int bridge1Coin20;
    public int bridge1Coin21;
    public int bridge1Coin22;
    public int bridge1Coin23;
    public int bridge1Coin24;
    //1-8
    public int bridge2Coin1;
    public int bridge2Coin2;
    public int bridge2Coin3;
    public int bridge2Coin4;
    public int bridge2Coin5;
    public int bridge2Coin6;
    public int bridge2Coin7;
    public int bridge2Coin8;
    public int bridge2Coin9;
    public int bridge2Coin10;
    public int bridge2Coin11;
    public int bridge2Coin12;
    public int bridge2Coin13;
    public int bridge2Coin14;
    public int bridge2Coin15;
    public int bridge2Coin16;
    public int bridge2Coin17;
    public int bridge2Coin18;
    public int bridge2Coin19;
    public int bridge2Coin20;
    public int bridge2Coin21;
    public int bridge2Coin22;
    public int bridge2Coin23;
    public int bridge2Coin24;
    public int bridge2Coin25;
    public int bridge2Coin26;
    public int bridge2Coin27;
    public int bridge2Coin28;
    public int bridge2Coin29;
    public int bridge2Coin30;
    public int bridge2Coin31;
    public int bridge2Coin32;
    public int bridge2Coin33;
    public int bridge2Coin34;
    public int bridge2Coin35;
    public int bridge2Coin36;
    //1-10
    public int doorItem1;
    public int doorCoin1;
    public int doorCoin2;
    public int doorCoin3;
    public int doorCoin4;
    public int doorCoin5;
    public int doorCoin6;
    public int doorCoin7;
    public int doorCoin8;
    public int doorCoin9;
    public int doorCoin10;
    public int doorCoin11;
    public int doorCoin12;
    public int doorCoin13;
    public int doorCoin14;
    //1-11
    public int base1Item1;
    public int base1Item2;
    public int base1Coin1;
    public int base1Coin2;
    public int base1Coin3;
    public int base1Coin4;
    public int base1Coin5;
    public int base1Coin6;
    public int base1Coin7;
    public int base1Coin8;
    public int base1Coin9;
    //1-12
    public int base2Item1;
    public int base2Item2;
    public int base2Gem1;
    public int base2Coin1;
    public int base2Coin2;
    public int base2Coin3;
    public int base2Coin4;
    public int base2Coin5;
    public int base2Coin6;
    public int base2Coin7;
    public int base2Coin8;
    public int base2Coin9;
    public int base2Coin10;
    public int base2Coin11;
    public int base2Coin12;
    public int base2Coin13;
    public int base2Coin14;
    public int base2Coin15;
    public int base2Coin16;
    public int base2Coin17;
    public int base2Coin18;
    public int base2Coin19;
    public int base2Coin20;
    public int base2Coin21;
    public int base2DoorOpened;


    //Contructor to use when saving the game
    public GameDataScript(CurrentDataScript current)
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
        storageItem1 = current.storageItem1;
        storageItem2 = current.storageItem2;
        brokenBridgeItem1 = current.brokenBridgeItem1;
        brokenBridgeItem2 = current.brokenBridgeItem2;
        brokenBridgeCoin1 = current.brokenBridgeCoin1;
        brokenBridgeCoin2 = current.brokenBridgeCoin2;
        brokenBridgeCoin3 = current.brokenBridgeCoin3;
        brokenBridgeCoin4 = current.brokenBridgeCoin4;
        brokenBridgeCoin5 = current.brokenBridgeCoin5;
        brokenBridgeCoin6 = current.brokenBridgeCoin6;
        brokenBridgeCoin7 = current.brokenBridgeCoin7;
        brokenBridgeCoin8 = current.brokenBridgeCoin8;
        brokenBridgeCoin9 = current.brokenBridgeCoin9;
        brokenBridgeCoin10 = current.brokenBridgeCoin10;
        brokenBridgeCoin11 = current.brokenBridgeCoin11;
        brokenBridgeCoin12 = current.brokenBridgeCoin12;
        brokenBridgeCoin13 = current.brokenBridgeCoin13;
        brokenBridgeCoin14 = current.brokenBridgeCoin14;
        brokenBridgeCoin15 = current.brokenBridgeCoin15;
        brokenBridgeCoin16 = current.brokenBridgeCoin16;
        citySideItem1 = current.citySideItem1;
        citySideGem1 = current.citySideGem1;
        citySideCoin1 = current.citySideCoin1;
        citySideCoin2 = current.citySideCoin2;
        citySideCoin3 = current.citySideCoin3;
        citySideCoin4 = current.citySideCoin4;
        citySideCoin5 = current.citySideCoin5;
        citySideCoin6 = current.citySideCoin6;
        citySideCoin7 = current.citySideCoin7;
        citySideCoin8 = current.citySideCoin8;
        citySideCoin9 = current.citySideCoin9;
        citySideCoin10 = current.citySideCoin10;
        citySideCoin11 = current.citySideCoin11;
        citySideCoin12 = current.citySideCoin12;
        citySideCoin13 = current.citySideCoin13;
        citySideCoin14 = current.citySideCoin14;
        citySideCoin15 = current.citySideCoin15;
        citySideCoin16 = current.citySideCoin16;
        citySideCoin17 = current.citySideCoin17;
        citySideCoin18 = current.citySideCoin18;
        citySideCoin19 = current.citySideCoin19;
        citySideCoin20 = current.citySideCoin20;
        citySideCoin21 = current.citySideCoin21;
        citySideCoin22 = current.citySideCoin22;
        citySideCoin23 = current.citySideCoin23;
        citySideCoin24 = current.citySideCoin24;
        waterItem1 = current.waterItem1;
        waterClear = current.waterClear;
        bridge1Coin1 = current.bridge1Coin1;
        bridge1Coin2 = current.bridge1Coin2;
        bridge1Coin3 = current.bridge1Coin3;
        bridge1Coin4 = current.bridge1Coin4;
        bridge1Coin5 = current.bridge1Coin5;
        bridge1Coin6 = current.bridge1Coin6;
        bridge1Coin7 = current.bridge1Coin7;
        bridge1Coin8 = current.bridge1Coin8;
        bridge1Coin9 = current.bridge1Coin9;
        bridge1Coin10 = current.bridge1Coin10;
        bridge1Coin11 = current.bridge1Coin11;
        bridge1Coin12 = current.bridge1Coin12;
        bridge1Coin13 = current.bridge1Coin13;
        bridge1Coin14 = current.bridge1Coin14;
        bridge1Coin15 = current.bridge1Coin15;
        bridge1Coin16 = current.bridge1Coin16;
        bridge1Coin17 = current.bridge1Coin17;
        bridge1Coin18 = current.bridge1Coin18;
        bridge1Coin19 = current.bridge1Coin19;
        bridge1Coin20 = current.bridge1Coin20;
        bridge1Coin21 = current.bridge1Coin21;
        bridge1Coin22 = current.bridge1Coin22;
        bridge1Coin23 = current.bridge1Coin23;
        bridge1Coin24 = current.bridge1Coin24;
        bridge2Coin1 = current.bridge2Coin1;
        bridge2Coin2 = current.bridge2Coin2;
        bridge2Coin3 = current.bridge2Coin3;
        bridge2Coin4 = current.bridge2Coin4;
        bridge2Coin5 = current.bridge2Coin5;
        bridge2Coin6 = current.bridge2Coin6;
        bridge2Coin7 = current.bridge2Coin7;
        bridge2Coin8 = current.bridge2Coin8;
        bridge2Coin9 = current.bridge2Coin9;
        bridge2Coin10 = current.bridge2Coin10;
        bridge2Coin11 = current.bridge2Coin11;
        bridge2Coin12 = current.bridge2Coin12;
        bridge2Coin13 = current.bridge2Coin13;
        bridge2Coin14 = current.bridge2Coin14;
        bridge2Coin15 = current.bridge2Coin15;
        bridge2Coin16 = current.bridge2Coin16;
        bridge2Coin17 = current.bridge2Coin17;
        bridge2Coin18 = current.bridge2Coin18;
        bridge2Coin19 = current.bridge2Coin19;
        bridge2Coin20 = current.bridge2Coin20;
        bridge2Coin21 = current.bridge2Coin21;
        bridge2Coin22 = current.bridge2Coin22;
        bridge2Coin23 = current.bridge2Coin23;
        bridge2Coin24 = current.bridge2Coin24;
        bridge2Coin25 = current.bridge2Coin25;
        bridge2Coin26 = current.bridge2Coin26;
        bridge2Coin27 = current.bridge2Coin27;
        bridge2Coin28 = current.bridge2Coin28;
        bridge2Coin29 = current.bridge2Coin29;
        bridge2Coin30 = current.bridge2Coin30;
        bridge2Coin31 = current.bridge2Coin31;
        bridge2Coin32 = current.bridge2Coin32;
        bridge2Coin33 = current.bridge2Coin33;
        bridge2Coin34 = current.bridge2Coin34;
        bridge2Coin35 = current.bridge2Coin35;
        bridge2Coin36 = current.bridge2Coin36;
        doorItem1 = current.doorItem1;
        doorCoin1 = current.doorCoin1;
        doorCoin2 = current.doorCoin2;
        doorCoin3 = current.doorCoin3;
        doorCoin4 = current.doorCoin4;
        doorCoin5 = current.doorCoin5;
        doorCoin6 = current.doorCoin6;
        doorCoin7 = current.doorCoin7;
        doorCoin8 = current.doorCoin8;
        doorCoin9 = current.doorCoin9;
        doorCoin10 = current.doorCoin10;
        doorCoin11 = current.doorCoin11;
        doorCoin12 = current.doorCoin12;
        doorCoin13 = current.doorCoin13;
        doorCoin14 = current.doorCoin14;
        base1Item1 = current.base1Item1;
        base1Item2 = current.base1Item2;
        base1Coin1 = current.base1Coin1;
        base1Coin2 = current.base1Coin2;
        base1Coin3 = current.base1Coin3;
        base1Coin4 = current.base1Coin4;
        base1Coin5 = current.base1Coin5;
        base1Coin6 = current.base1Coin6;
        base1Coin7 = current.base1Coin7;
        base1Coin8 = current.base1Coin8;
        base1Coin9 = current.base1Coin9;
        base2Item1 = current.base2Item1;
        base2Item2 = current.base2Item2;
        base2Gem1 = current.base2Gem1;
        base2Coin1 = current.base2Coin1;
        base2Coin2 = current.base2Coin2;
        base2Coin3 = current.base2Coin3;
        base2Coin4 = current.base2Coin4;
        base2Coin5 = current.base2Coin5;
        base2Coin6 = current.base2Coin6;
        base2Coin7 = current.base2Coin7;
        base2Coin8 = current.base2Coin8;
        base2Coin9 = current.base2Coin9;
        base2Coin10 = current.base2Coin10;
        base2Coin11 = current.base2Coin11;
        base2Coin12 = current.base2Coin12;
        base2Coin13 = current.base2Coin13;
        base2Coin14 = current.base2Coin14;
        base2Coin15 = current.base2Coin15;
        base2Coin16 = current.base2Coin16;
        base2Coin17 = current.base2Coin17;
        base2Coin18 = current.base2Coin18;
        base2Coin19 = current.base2Coin19;
        base2Coin20 = current.base2Coin20;
        base2Coin21 = current.base2Coin21;
        base2DoorOpened = current.base2DoorOpened;
    }
}