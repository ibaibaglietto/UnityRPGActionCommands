using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CurrentDataScript : MonoBehaviour
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
    //Tutorial
    public int tutorialState;
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
    public int base2Dialogue;
    //1-13
    public int base3BossDefeated;
    //1-14
    public int base4BossDefeated;
    //1-15
    public int base5BossDefeated;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Data");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

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

    //Function to set a flag
    public void SetFlag(string flag)
    {
        //1-2
        if (flag == "storageItem1") storageItem1 = 1;
        else if (flag == "storageItem2") storageItem2 = 1;
        //1-3
        else if (flag == "cityItem1") cityItem1 = 1;
        else if (flag == "cityGem1") cityGem1 = 1;
        else if (flag == "cityCoin1") cityCoin1 = 1;
        else if (flag == "cityCoin2") cityCoin2 = 1;
        else if (flag == "cityCoin3") cityCoin3 = 1;
        else if (flag == "cityCoin4") cityCoin4 = 1;
        else if (flag == "cityCoin5") cityCoin5 = 1;
        else if (flag == "cityCoin6") cityCoin6 = 1;
        else if (flag == "cityCoin7") cityCoin7 = 1;
        else if (flag == "cityCoin8") cityCoin8 = 1;
        else if (flag == "cityCoin9") cityCoin9 = 1;
        else if (flag == "cityCoin10") cityCoin10 = 1;
        else if (flag == "cityCoin11") cityCoin11 = 1;
        else if (flag == "cityCoin12") cityCoin12 = 1;
        //1-4
        else if (flag == "brokenBridgeItem1") brokenBridgeItem1 = 1;
        else if (flag == "brokenBridgeItem2") brokenBridgeItem2 = 1;
        else if (flag == "brokenBridgeCoin1") brokenBridgeCoin1 = 1;
        else if (flag == "brokenBridgeCoin2") brokenBridgeCoin2 = 1;
        else if (flag == "brokenBridgeCoin3") brokenBridgeCoin3 = 1;
        else if (flag == "brokenBridgeCoin4") brokenBridgeCoin4 = 1;
        else if (flag == "brokenBridgeCoin5") brokenBridgeCoin5 = 1;
        else if (flag == "brokenBridgeCoin6") brokenBridgeCoin6 = 1;
        else if (flag == "brokenBridgeCoin7") brokenBridgeCoin7 = 1;
        else if (flag == "brokenBridgeCoin8") brokenBridgeCoin8 = 1;
        else if (flag == "brokenBridgeCoin9") brokenBridgeCoin9 = 1;
        else if (flag == "brokenBridgeCoin10") brokenBridgeCoin10 = 1;
        else if (flag == "brokenBridgeCoin11") brokenBridgeCoin11 = 1;
        else if (flag == "brokenBridgeCoin12") brokenBridgeCoin12 = 1;
        else if (flag == "brokenBridgeCoin13") brokenBridgeCoin13 = 1;
        else if (flag == "brokenBridgeCoin14") brokenBridgeCoin14 = 1;
        else if (flag == "brokenBridgeCoin15") brokenBridgeCoin15 = 1;
        else if (flag == "brokenBridgeCoin16") brokenBridgeCoin16 = 1;
        //1-5
        else if (flag == "citySideItem1") citySideItem1 = 1;
        else if (flag == "citySideGem1") citySideGem1 = 1;
        else if (flag == "citySideCoin1") citySideCoin1 = 1;
        else if (flag == "citySideCoin2") citySideCoin2 = 1;
        else if (flag == "citySideCoin3") citySideCoin3 = 1;
        else if (flag == "citySideCoin4") citySideCoin4 = 1;
        else if (flag == "citySideCoin5") citySideCoin5 = 1;
        else if (flag == "citySideCoin6") citySideCoin6 = 1;
        else if (flag == "citySideCoin7") citySideCoin7 = 1;
        else if (flag == "citySideCoin8") citySideCoin8 = 1;
        else if (flag == "citySideCoin9") citySideCoin9 = 1;
        else if (flag == "citySideCoin10") citySideCoin10 = 1;
        else if (flag == "citySideCoin11") citySideCoin11 = 1;
        else if (flag == "citySideCoin12") citySideCoin12 = 1;
        else if (flag == "citySideCoin13") citySideCoin13 = 1;
        else if (flag == "citySideCoin14") citySideCoin14 = 1;
        else if (flag == "citySideCoin15") citySideCoin15 = 1;
        else if (flag == "citySideCoin16") citySideCoin16 = 1;
        else if (flag == "citySideCoin17") citySideCoin17 = 1;
        else if (flag == "citySideCoin18") citySideCoin18 = 1;
        else if (flag == "citySideCoin19") citySideCoin19 = 1;
        else if (flag == "citySideCoin20") citySideCoin20 = 1;
        else if (flag == "citySideCoin21") citySideCoin21 = 1;
        else if (flag == "citySideCoin22") citySideCoin22 = 1;
        else if (flag == "citySideCoin23") citySideCoin23 = 1;
        else if (flag == "citySideCoin24") citySideCoin24 = 1;
        //1-6
        else if (flag == "waterItem1") waterItem1 = 1;
        //1-7
        else if (flag == "bridge1Coin1") bridge1Coin1 = 1;
        else if (flag == "bridge1Coin2") bridge1Coin2 = 1;
        else if (flag == "bridge1Coin3") bridge1Coin3 = 1;
        else if (flag == "bridge1Coin4") bridge1Coin4 = 1;
        else if (flag == "bridge1Coin5") bridge1Coin5 = 1;
        else if (flag == "bridge1Coin6") bridge1Coin6 = 1;
        else if (flag == "bridge1Coin7") bridge1Coin7 = 1;
        else if (flag == "bridge1Coin8") bridge1Coin8 = 1;
        else if (flag == "bridge1Coin9") bridge1Coin9 = 1;
        else if (flag == "bridge1Coin10") bridge1Coin10 = 1;
        else if (flag == "bridge1Coin11") bridge1Coin11 = 1;
        else if (flag == "bridge1Coin12") bridge1Coin12 = 1;
        else if (flag == "bridge1Coin13") bridge1Coin13 = 1;
        else if (flag == "bridge1Coin14") bridge1Coin14 = 1;
        else if (flag == "bridge1Coin15") bridge1Coin15 = 1;
        else if (flag == "bridge1Coin16") bridge1Coin16 = 1;
        else if (flag == "bridge1Coin17") bridge1Coin17 = 1;
        else if (flag == "bridge1Coin18") bridge1Coin18 = 1;
        else if (flag == "bridge1Coin19") bridge1Coin19 = 1;
        else if (flag == "bridge1Coin20") bridge1Coin20 = 1;
        else if (flag == "bridge1Coin21") bridge1Coin21 = 1;
        else if (flag == "bridge1Coin22") bridge1Coin22 = 1;
        else if (flag == "bridge1Coin23") bridge1Coin23 = 1;
        else if (flag == "bridge1Coin24") bridge1Coin24 = 1;
        //1-8
        else if (flag == "bridge2Coin1") bridge2Coin1 = 1;
        else if (flag == "bridge2Coin2") bridge2Coin2 = 1;
        else if (flag == "bridge2Coin3") bridge2Coin3 = 1;
        else if (flag == "bridge2Coin4") bridge2Coin4 = 1;
        else if (flag == "bridge2Coin5") bridge2Coin5 = 1;
        else if (flag == "bridge2Coin6") bridge2Coin6 = 1;
        else if (flag == "bridge2Coin7") bridge2Coin7 = 1;
        else if (flag == "bridge2Coin8") bridge2Coin8 = 1;
        else if (flag == "bridge2Coin9") bridge2Coin9 = 1;
        else if (flag == "bridge2Coin10") bridge2Coin10 = 1;
        else if (flag == "bridge2Coin11") bridge2Coin11 = 1;
        else if (flag == "bridge2Coin12") bridge2Coin12 = 1;
        else if (flag == "bridge2Coin13") bridge2Coin13 = 1;
        else if (flag == "bridge2Coin14") bridge2Coin14 = 1;
        else if (flag == "bridge2Coin15") bridge2Coin15 = 1;
        else if (flag == "bridge2Coin16") bridge2Coin16 = 1;
        else if (flag == "bridge2Coin17") bridge2Coin17 = 1;
        else if (flag == "bridge2Coin18") bridge2Coin18 = 1;
        else if (flag == "bridge2Coin19") bridge2Coin19 = 1;
        else if (flag == "bridge2Coin20") bridge2Coin20 = 1;
        else if (flag == "bridge2Coin21") bridge2Coin21 = 1;
        else if (flag == "bridge2Coin22") bridge2Coin22 = 1;
        else if (flag == "bridge2Coin23") bridge2Coin23 = 1;
        else if (flag == "bridge2Coin24") bridge2Coin24 = 1;
        else if (flag == "bridge2Coin25") bridge2Coin25 = 1;
        else if (flag == "bridge2Coin26") bridge2Coin26 = 1;
        else if (flag == "bridge2Coin27") bridge2Coin27 = 1;
        else if (flag == "bridge2Coin28") bridge2Coin28 = 1;
        else if (flag == "bridge2Coin29") bridge2Coin29 = 1;
        else if (flag == "bridge2Coin30") bridge2Coin30 = 1;
        else if (flag == "bridge2Coin31") bridge2Coin31 = 1;
        else if (flag == "bridge2Coin32") bridge2Coin32 = 1;
        else if (flag == "bridge2Coin33") bridge2Coin33 = 1;
        else if (flag == "bridge2Coin34") bridge2Coin34 = 1;
        else if (flag == "bridge2Coin35") bridge2Coin35 = 1;
        else if (flag == "bridge2Coin36") bridge2Coin36 = 1;
        //1-10
        else if (flag == "doorItem1") doorItem1 = 1;
        else if (flag == "doorCoin1") doorCoin1 = 1;
        else if (flag == "doorCoin2") doorCoin2 = 1;
        else if (flag == "doorCoin3") doorCoin3 = 1;
        else if (flag == "doorCoin4") doorCoin4 = 1;
        else if (flag == "doorCoin5") doorCoin5 = 1;
        else if (flag == "doorCoin6") doorCoin6 = 1;
        else if (flag == "doorCoin7") doorCoin7 = 1;
        else if (flag == "doorCoin8") doorCoin8 = 1;
        else if (flag == "doorCoin9") doorCoin9 = 1;
        else if (flag == "doorCoin10") doorCoin10 = 1;
        else if (flag == "doorCoin11") doorCoin11 = 1;
        else if (flag == "doorCoin12") doorCoin12 = 1;
        else if (flag == "doorCoin13") doorCoin13 = 1;
        else if (flag == "doorCoin14") doorCoin14 = 1;
        //1-11
        else if (flag == "base1Item1") base1Item1 = 1;
        else if (flag == "base1Item2") base1Item2 = 1;
        else if (flag == "base1Coin1") base1Coin1 = 1;
        else if (flag == "base1Coin2") base1Coin2 = 1;
        else if (flag == "base1Coin3") base1Coin3 = 1;
        else if (flag == "base1Coin4") base1Coin4 = 1;
        else if (flag == "base1Coin5") base1Coin5 = 1;
        else if (flag == "base1Coin6") base1Coin6 = 1;
        else if (flag == "base1Coin7") base1Coin7 = 1;
        else if (flag == "base1Coin8") base1Coin8 = 1;
        else if (flag == "base1Coin9") base1Coin9 = 1;
        //1-12
        else if (flag == "base2Item1") base2Item1 = 1;
        else if (flag == "base2Item2") base2Item2 = 1;
        else if (flag == "base2Gem1") base2Gem1 = 1;
        else if (flag == "base2Coin1") base2Coin1 = 1;
        else if (flag == "base2Coin2") base2Coin2 = 1;
        else if (flag == "base2Coin3") base2Coin3 = 1;
        else if (flag == "base2Coin4") base2Coin4 = 1;
        else if (flag == "base2Coin5") base2Coin5 = 1;
        else if (flag == "base2Coin6") base2Coin6 = 1;
        else if (flag == "base2Coin7") base2Coin7 = 1;
        else if (flag == "base2Coin8") base2Coin8 = 1;
        else if (flag == "base2Coin9") base2Coin9 = 1;
        else if (flag == "base2Coin10") base2Coin10 = 1;
        else if (flag == "base2Coin11") base2Coin11 = 1;
        else if (flag == "base2Coin12") base2Coin12 = 1;
        else if (flag == "base2Coin13") base2Coin13 = 1;
        else if (flag == "base2Coin14") base2Coin14 = 1;
        else if (flag == "base2Coin15") base2Coin15 = 1;
        else if (flag == "base2Coin16") base2Coin16 = 1;
        else if (flag == "base2Coin17") base2Coin17 = 1;
        else if (flag == "base2Coin18") base2Coin18 = 1;
        else if (flag == "base2Coin19") base2Coin19 = 1;
        else if (flag == "base2Coin20") base2Coin20 = 1;
        else if (flag == "base2Coin21") base2Coin21 = 1;
        else if (flag == "base2DoorOpened") base2DoorOpened = 1;
        else if (flag == "base2Dialogue") base2Dialogue = 1;
        //1-13
        else if (flag == "base3BossDefeated") base3BossDefeated = 1;
        //1-14
        else if (flag == "base4BossDefeated") base4BossDefeated = 1;
        //1-14
        else if (flag == "base5BossDefeated") base5BossDefeated = 1;
    }

    //Function to load the data
    public void LoadData(GameDataScript data)
    {
        spawnX = data.spawnX;
        spawnY = data.spawnY;
        spawnZ = data.spawnZ;
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
        storedItems = data.storedItems;
        changingScene = data.changingScene;
        movLeft = data.movLeft;
        movRight = data.movRight;
        movUp = data.movUp;
        movDown = data.movDown;
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
        availableGems = data.availableGems;
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
        knight = data.knight;
        firstAttackObjective = data.firstAttackObjective;
        playerAttackFirst = data.playerAttackFirst;
        playerAttack = data.playerAttack;
        playerStyle = data.playerStyle;
        companionAttack = data.companionAttack;
        companionStyle = data.companionStyle;
        tutorialState = data.tutorialState;
        clearJail = data.clearJail;
        storageItem1 = data.storageItem1;
        storageItem2 = data.storageItem2;
        brokenBridgeItem1 = data.brokenBridgeItem1;
        brokenBridgeItem2 = data.brokenBridgeItem2;
        brokenBridgeCoin1 = data.brokenBridgeCoin1;
        brokenBridgeCoin2 = data.brokenBridgeCoin2;
        brokenBridgeCoin3 = data.brokenBridgeCoin3;
        brokenBridgeCoin4 = data.brokenBridgeCoin4;
        brokenBridgeCoin5 = data.brokenBridgeCoin5;
        brokenBridgeCoin6 = data.brokenBridgeCoin6;
        brokenBridgeCoin7 = data.brokenBridgeCoin7;
        brokenBridgeCoin8 = data.brokenBridgeCoin8;
        brokenBridgeCoin9 = data.brokenBridgeCoin9;
        brokenBridgeCoin10 = data.brokenBridgeCoin10;
        brokenBridgeCoin11 = data.brokenBridgeCoin11;
        brokenBridgeCoin12 = data.brokenBridgeCoin12;
        brokenBridgeCoin13 = data.brokenBridgeCoin13;
        brokenBridgeCoin14 = data.brokenBridgeCoin14;
        brokenBridgeCoin15 = data.brokenBridgeCoin15;
        brokenBridgeCoin16 = data.brokenBridgeCoin16;
        citySideItem1 = data.citySideItem1;
        citySideGem1 = data.citySideGem1;
        citySideCoin1 = data.citySideCoin1;
        citySideCoin2 = data.citySideCoin2;
        citySideCoin3 = data.citySideCoin3;
        citySideCoin4 = data.citySideCoin4;
        citySideCoin5 = data.citySideCoin5;
        citySideCoin6 = data.citySideCoin6;
        citySideCoin7 = data.citySideCoin7;
        citySideCoin8 = data.citySideCoin8;
        citySideCoin9 = data.citySideCoin9;
        citySideCoin10 = data.citySideCoin10;
        citySideCoin11 = data.citySideCoin11;
        citySideCoin12 = data.citySideCoin12;
        citySideCoin13 = data.citySideCoin13;
        citySideCoin14 = data.citySideCoin14;
        citySideCoin15 = data.citySideCoin15;
        citySideCoin16 = data.citySideCoin16;
        citySideCoin17 = data.citySideCoin17;
        citySideCoin18 = data.citySideCoin18;
        citySideCoin19 = data.citySideCoin19;
        citySideCoin20 = data.citySideCoin20;
        citySideCoin21 = data.citySideCoin21;
        citySideCoin22 = data.citySideCoin22;
        citySideCoin23 = data.citySideCoin23;
        citySideCoin24 = data.citySideCoin24;
        waterItem1 = data.waterItem1;
        waterClear = data.waterClear;
        bridge1Coin1 = data.bridge1Coin1;
        bridge1Coin2 = data.bridge1Coin2;
        bridge1Coin3 = data.bridge1Coin3;
        bridge1Coin4 = data.bridge1Coin4;
        bridge1Coin5 = data.bridge1Coin5;
        bridge1Coin6 = data.bridge1Coin6;
        bridge1Coin7 = data.bridge1Coin7;
        bridge1Coin8 = data.bridge1Coin8;
        bridge1Coin9 = data.bridge1Coin9;
        bridge1Coin10 = data.bridge1Coin10;
        bridge1Coin11 = data.bridge1Coin11;
        bridge1Coin12 = data.bridge1Coin12;
        bridge1Coin13 = data.bridge1Coin13;
        bridge1Coin14 = data.bridge1Coin14;
        bridge1Coin15 = data.bridge1Coin15;
        bridge1Coin16 = data.bridge1Coin16;
        bridge1Coin17 = data.bridge1Coin17;
        bridge1Coin18 = data.bridge1Coin18;
        bridge1Coin19 = data.bridge1Coin19;
        bridge1Coin20 = data.bridge1Coin20;
        bridge1Coin21 = data.bridge1Coin21;
        bridge1Coin22 = data.bridge1Coin22;
        bridge1Coin23 = data.bridge1Coin23;
        bridge1Coin24 = data.bridge1Coin24;
        bridge2Coin1 = data.bridge2Coin1;
        bridge2Coin2 = data.bridge2Coin2;
        bridge2Coin3 = data.bridge2Coin3;
        bridge2Coin4 = data.bridge2Coin4;
        bridge2Coin5 = data.bridge2Coin5;
        bridge2Coin6 = data.bridge2Coin6;
        bridge2Coin7 = data.bridge2Coin7;
        bridge2Coin8 = data.bridge2Coin8;
        bridge2Coin9 = data.bridge2Coin9;
        bridge2Coin10 = data.bridge2Coin10;
        bridge2Coin11 = data.bridge2Coin11;
        bridge2Coin12 = data.bridge2Coin12;
        bridge2Coin13 = data.bridge2Coin13;
        bridge2Coin14 = data.bridge2Coin14;
        bridge2Coin15 = data.bridge2Coin15;
        bridge2Coin16 = data.bridge2Coin16;
        bridge2Coin17 = data.bridge2Coin17;
        bridge2Coin18 = data.bridge2Coin18;
        bridge2Coin19 = data.bridge2Coin19;
        bridge2Coin20 = data.bridge2Coin20;
        bridge2Coin21 = data.bridge2Coin21;
        bridge2Coin22 = data.bridge2Coin22;
        bridge2Coin23 = data.bridge2Coin23;
        bridge2Coin24 = data.bridge2Coin24;
        bridge2Coin25 = data.bridge2Coin25;
        bridge2Coin26 = data.bridge2Coin26;
        bridge2Coin27 = data.bridge2Coin27;
        bridge2Coin28 = data.bridge2Coin28;
        bridge2Coin29 = data.bridge2Coin29;
        bridge2Coin30 = data.bridge2Coin30;
        bridge2Coin31 = data.bridge2Coin31;
        bridge2Coin32 = data.bridge2Coin32;
        bridge2Coin33 = data.bridge2Coin33;
        bridge2Coin34 = data.bridge2Coin34;
        bridge2Coin35 = data.bridge2Coin35;
        bridge2Coin36 = data.bridge2Coin36;
        doorItem1 = data.doorItem1;
        doorCoin1 = data.doorCoin1;
        doorCoin2 = data.doorCoin2;
        doorCoin3 = data.doorCoin3;
        doorCoin4 = data.doorCoin4;
        doorCoin5 = data.doorCoin5;
        doorCoin6 = data.doorCoin6;
        doorCoin7 = data.doorCoin7;
        doorCoin8 = data.doorCoin8;
        doorCoin9 = data.doorCoin9;
        doorCoin10 = data.doorCoin10;
        doorCoin11 = data.doorCoin11;
        doorCoin12 = data.doorCoin12;
        doorCoin13 = data.doorCoin13;
        doorCoin14 = data.doorCoin14;
        base1Item1 = data.base1Item1;
        base1Item2 = data.base1Item2;
        base1Coin1 = data.base1Coin1;
        base1Coin2 = data.base1Coin2;
        base1Coin3 = data.base1Coin3;
        base1Coin4 = data.base1Coin4;
        base1Coin5 = data.base1Coin5;
        base1Coin6 = data.base1Coin6;
        base1Coin7 = data.base1Coin7;
        base1Coin8 = data.base1Coin8;
        base1Coin9 = data.base1Coin9;
        base2Item1 = data.base2Item1;
        base2Item2 = data.base2Item2;
        base2Gem1 = data.base2Gem1;
        base2Coin1 = data.base2Coin1;
        base2Coin2 = data.base2Coin2;
        base2Coin3 = data.base2Coin3;
        base2Coin4 = data.base2Coin4;
        base2Coin5 = data.base2Coin5;
        base2Coin6 = data.base2Coin6;
        base2Coin7 = data.base2Coin7;
        base2Coin8 = data.base2Coin8;
        base2Coin9 = data.base2Coin9;
        base2Coin10 = data.base2Coin10;
        base2Coin11 = data.base2Coin11;
        base2Coin12 = data.base2Coin12;
        base2Coin13 = data.base2Coin13;
        base2Coin14 = data.base2Coin14;
        base2Coin15 = data.base2Coin15;
        base2Coin16 = data.base2Coin16;
        base2Coin17 = data.base2Coin17;
        base2Coin18 = data.base2Coin18;
        base2Coin19 = data.base2Coin19;
        base2Coin20 = data.base2Coin20;
        base2Coin21 = data.base2Coin21;
        base2DoorOpened = data.base2DoorOpened;
        base2Dialogue = data.base2Dialogue;
        base3BossDefeated = data.base3BossDefeated;
        base4BossDefeated = data.base4BossDefeated;
        base5BossDefeated = data.base5BossDefeated;
    }


    //A function to know if a gem is already found
    public bool IsGemFound(int id)
    {
        if(id == 1) return lightSwordFound == 1;
        else if (id == 2) return multistrikeSwordFound == 1;
        else if (id == 3) return lightShurikenFound == 1;
        else if (id == 4) return fireShurikenFound == 1;
        else if (id == 5) return HPUpFound == 1;
        else if (id == 6) return LPUpFound == 1;
        else if (id == 7) return compHPUpFound == 1;
        return false;
    }

    //A funstion to set a gem to found or not
    public void SetGemFound(int id, int found)
    {
        if (id == 1) lightSwordFound = found;
        else if (id == 2) multistrikeSwordFound = found;
        else if (id == 3) lightShurikenFound = found;
        else if (id == 4) fireShurikenFound = found;
        else if (id == 5) HPUpFound = found;
        else if (id == 6) LPUpFound = found;
        else if (id == 7) compHPUpFound = found;
        availableGems = lightSwordFound + multistrikeSwordFound + lightShurikenFound + fireShurikenFound + HPUpFound + LPUpFound + compHPUpFound;
    }

    public void AddItem(int id)
    {
        if(itemSize()<20) items[itemSize()] = id;
    }

    //Function to know the number of items the player has
    public int itemSize()
    {
        int i = 0;
        while (i < 20 && items[i] != 0)
        {
            i++;
        }
        return i;
    }

    //Function to delete an item
    public void DeleteItem(int pos)
    {
        for (int i = pos; i < itemSize(); i++)
        {
            if (i < 19) items[i] = items[i + 1];
            else items[i] = 0;
        }
    }

    public void AddStoredItem(int id)
    {
        storedItems[StoredItemSize()] = id;
    }

    //Function to know the number of items the player has
    public int StoredItemSize()
    {
        int i = 0;
        while (i < 99 && storedItems[i] != 0)
        {
            i++;
        }
        return i;
    }

    //Function to delete an item
    public void DeleteStoredItem(int pos)
    {
        for (int i = pos; i < StoredItemSize(); i++)
        {
            if (i < 98) storedItems[i] = storedItems[i + 1];
            else storedItems[i] = 0;
        }
    }

    //Function to know the price of an item
    public int ItemPrice(int id, bool isGem)
    {
        if (!isGem)
        {
            if (id == 1) return 10;
            else if (id == 2) return 10;
            else return 30;
        }
        else
        {
            if (id == 1) return 50;
            else if (id == 2) return 100;
            else if (id == 3) return 50;
            else if (id == 4) return 100;
            else if (id == 5) return 50;
            else if (id == 6) return 50;
            else return 150;
        }
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            if(e.keyCode == KeyCode.LeftArrow)
            {
                if (e.type == EventType.KeyDown) movLeft = true;
                else if (e.type == EventType.KeyUp) movLeft = false;
            }
            else if (e.keyCode == KeyCode.RightArrow)
            {
                if (e.type == EventType.KeyDown) movRight = true;
                else if (e.type == EventType.KeyUp) movRight = false;
            }
            else if (e.keyCode == KeyCode.UpArrow)
            {
                if (e.type == EventType.KeyDown) movUp = true;
                else if (e.type == EventType.KeyUp) movUp = false;
            }
            else if (e.keyCode == KeyCode.DownArrow)
            {
                if (e.type == EventType.KeyDown) movDown = true;
                else if (e.type == EventType.KeyUp) movDown = false;
            }
        }
    }
}
