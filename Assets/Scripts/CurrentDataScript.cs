using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CurrentDataScript : MonoBehaviour
{

    public int fled;
    public int playerFirstAttack;
    public int companionFirstAttack;
    public int enemyStart;
    public int fisrtAttackObjective;
    public int lvlExp;
    public int enemyDied;
    public int playerLvl;
    public int playerHeartLvl;
    public int playerLightLvl;
    public int playerBadgeLvl;
    public int adventurerCurrentHealth;
    public int wizardCurrentHealth;
    public int currentCoins;
    public int battle;
    public int playerCurrentLight;
    public int lightSword;
    public int multistrikeSword;
    public int swordStyles;
    public int lightShuriken;
    public int fireShuriken;
    public int shurikenStyles;
    public int souls;
    public int playerCurrentHealth;
    public int adventurerLvl;
    public int wizardLvl;
    public int swordLvl;
    public int shurikenLvl;
    public int language;
    public int enemy1;
    public int enemy2;
    public int enemy3;
    public int enemy4;
    public float master;
    public float music;
    public float effects;
    public int unlockedCompanions;
    public int fullScreen;
    public int resolutionX;
    public int resolutionY;
    public int first;
    public int bandit;
    public int wizard;
    public int king;
    public int currentCompanion;
    public int firstAttackObjective;
    public int playerAttackFirst;
    public int playerAttack;
    public int playerStyle;
    public int companionAttack;
    public int companionStyle;
    public int lightSwordFound;
    public int multistrikeSwordFound;
    public int lightShurikenFound;
    public int fireShurikenFound;
    public int HPUp;
    public int LPUp;
    public int compHPUp;
    public int HPUpFound;
    public int LPUpFound;
    public int compHPUpFound;
    public int spentGP;
    public int[] items = { 2, 1, 1, 2, 3, 1, 1, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
