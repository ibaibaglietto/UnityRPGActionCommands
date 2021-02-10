using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    private GameObject mainMenu;
    private GameObject settings;
    private GameObject battleSettings;
    private GameObject confirmResolution;
    private GameObject howToPlay;
    private Slider masterSlider;
    private Slider musicSlider;
    private Slider effectsSlider;
    private Dropdown resolution;
    private Toggle fullscreen; 
    private Dropdown lifeLvl;
    private Dropdown lightLvl;
    private Dropdown swordLvl;
    private Dropdown shurikenLvl;
    private Dropdown adventurerLvl;
    private Dropdown wizardLvl;
    private Dropdown enemy1;
    private Dropdown enemy2;
    private Dropdown enemy3;
    private Dropdown enemy4;
    private float confirmTime;
    private Text confirmTimeNumb;
    private Button saveResolutionButton;
    private AudioSource effectsSource;
    private Dropdown language;
    //Int to know the actual explanation
    private int explanation;
    //The text we are going to change depending on the language
    private Text mainMenuStart;
    private Text mainMenuSettings;
    private Text mainMenuBattleSetting;
    private Text mainMenuHowToPlay;
    private Text mainMenuExit;
    private Text settingsTitle;
    private Text settingsMasterVolume;
    private Text settingsMusicVolume;
    private Text settingsEffectsVolume;
    private Text settingsFullScreen;
    private Text settingsResolution;
    private Text settingsSaveResolution;
    private Text settingsLanguage;
    private Text settingsClose;
    private Text settingsConfirmText1;
    private Text settingsConfirmText2;
    private Text settingsConfirm;
    private Text battleSettingsTitle;
    private Text battleSettingsPlayer;
    private Text battleSettingsLifePoints;
    private Text battleSettingsLightPoints;
    private Text battleSettingsSwordLevel;
    private Text battleSettingsShurikenLevel;
    private Text battleSettingsCompanions;
    private Text battleSettingsAdventurerLevel;
    private Text battleSettingsWizardLevel;
    private Text battleSettingsEnemy1;
    private Text battleSettingsEnemy2;
    private Text battleSettingsEnemy3;
    private Text battleSettingsEnemy4;
    private Text battleSettingsExplanationText;
    private Text battleSettingsSave;
    private Text howToPlayTitle;
    private Text howToPlayExplanation1;
    private Text howToPlayExplanation2;
    private Text howToPlayExplanation3;
    private Text howToPlayExplanation4;
    private Text howToPlayExplanation5;
    private Text howToPlayExplanation6;
    private Text howToPlayPrev;
    private Text howToPlayNext;
    private Text howToPlayClose;




    void Start()
    {
        PlayerPrefs.DeleteAll();
        //We initialize the playerprefs
        if (!PlayerPrefs.HasKey("First"))
        {
            PlayerPrefs.SetInt("Light Sword", 1);
            PlayerPrefs.SetInt("Multistrike Sword", 1);
            PlayerPrefs.SetInt("Sword Styles", PlayerPrefs.GetInt("Light Sword") + PlayerPrefs.GetInt("Multistrike Sword"));
            PlayerPrefs.SetInt("Light Shuriken", 1);
            PlayerPrefs.SetInt("Fire Shuriken", 1);
            PlayerPrefs.SetInt("Shuriken Styles", PlayerPrefs.GetInt("Light Shuriken") + PlayerPrefs.GetInt("Fire Shuriken"));
            PlayerPrefs.SetInt("Souls", 6);
            PlayerPrefs.SetInt("PlayerHeartLvl", 0);
            PlayerPrefs.SetInt("PlayerLightLvl", 0);
            PlayerPrefs.SetInt("PlayerBadgeLvl", 0);
            PlayerPrefs.SetInt("PlayerLvl", 1 + PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("PlayerLightLvl") + PlayerPrefs.GetInt("PlayerBadgeLvl"));
            PlayerPrefs.SetInt("PlayerCurrentHealth", 10);
            PlayerPrefs.SetInt("AdventurerLvl", 1); //3
            PlayerPrefs.SetInt("AdventurerCurrentHealth", 20);
            PlayerPrefs.SetInt("WizardLvl", 1); //3
            PlayerPrefs.SetInt("WizardCurrentHealth", 25);
            PlayerPrefs.SetInt("SwordLvl", 1); //3
            PlayerPrefs.SetInt("ShurikenLvl", 1); //3
            PlayerPrefs.SetInt("language", 0);
            PlayerPrefs.SetInt("lvlXP", 90);
            PlayerPrefs.SetInt("Enemy1", 0);
            PlayerPrefs.SetInt("Enemy2", 0);
            PlayerPrefs.SetInt("Enemy3", 0);
            PlayerPrefs.SetInt("Enemy4", 0);
            PlayerPrefs.SetFloat("Master", 1.0f);
            PlayerPrefs.SetFloat("Music", 1.0f);
            PlayerPrefs.SetFloat("Effects", 1.0f);
            PlayerPrefs.SetInt("UnlockedCompanions", 2);
            PlayerPrefs.SetInt("FullScreen", 1);
            PlayerPrefs.SetInt("Resolutionx", 1280);
            PlayerPrefs.SetInt("Resolutiony", 720);
            PlayerPrefs.SetInt("Language", 1);//1 -> english, 2 -> español, 3 -> euskera
            PlayerPrefs.SetInt("First", 1);
        }
        PlayerPrefs.SetInt("bandit", 0);
        PlayerPrefs.SetInt("wizard", 0);
        PlayerPrefs.SetInt("king", 0);
        mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("Master")) * 20);
        mixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("Music")) * 20);
        mixer.SetFloat("Effects", Mathf.Log10(PlayerPrefs.GetFloat("Effects")) * 20);
        //We find the gameobjects
        mainMenu = transform.GetChild(1).gameObject;
        settings = transform.GetChild(2).gameObject;
        saveResolutionButton = settings.transform.Find("SaveResolution").GetComponent<Button>();
        battleSettings = transform.GetChild(3).gameObject;
        howToPlay = transform.GetChild(4).gameObject;
        confirmResolution = settings.transform.Find("ConfirmResolutionChange").gameObject;
        confirmTimeNumb = confirmResolution.transform.Find("TimeNumb").GetComponent<Text>();
        masterSlider = settings.transform.Find("MainVolumeSlider").GetComponent<Slider>();
        musicSlider = settings.transform.Find("MusicVolumeSlider").GetComponent<Slider>();
        effectsSlider = settings.transform.Find("EffectsVolumeSlider").GetComponent<Slider>();
        fullscreen = settings.transform.Find("FullScreenToggle").GetComponent<Toggle>();
        resolution = settings.transform.Find("ResolutionDropdown").GetComponent<Dropdown>();
        language = settings.transform.Find("LanguageDropdown").GetComponent<Dropdown>();
        lifeLvl = battleSettings.transform.Find("LifeLvlDropdown").GetComponent<Dropdown>();
        lightLvl = battleSettings.transform.Find("LightLvlDropdown").GetComponent<Dropdown>();
        swordLvl = battleSettings.transform.Find("SwordLvlDropdown").GetComponent<Dropdown>();
        shurikenLvl = battleSettings.transform.Find("ShurikenLvlDropdown").GetComponent<Dropdown>();
        adventurerLvl = battleSettings.transform.Find("AdventurerDropdown").GetComponent<Dropdown>();
        wizardLvl = battleSettings.transform.Find("WizardDropdown").GetComponent<Dropdown>();
        enemy1 = battleSettings.transform.Find("Enemy1Dropdown").GetComponent<Dropdown>();
        enemy2 = battleSettings.transform.Find("Enemy2Dropdown").GetComponent<Dropdown>();
        enemy3 = battleSettings.transform.Find("Enemy3Dropdown").GetComponent<Dropdown>();
        enemy4 = battleSettings.transform.Find("Enemy4Dropdown").GetComponent<Dropdown>();

        mainMenuStart = mainMenu.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        mainMenuSettings = mainMenu.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        mainMenuBattleSetting = mainMenu.transform.GetChild(3).GetChild(0).GetComponent<Text>();
        mainMenuHowToPlay = mainMenu.transform.GetChild(4).GetChild(0).GetComponent<Text>();
        mainMenuExit = mainMenu.transform.GetChild(5).GetChild(0).GetComponent<Text>();
        settingsTitle = settings.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        settingsMasterVolume = settings.transform.Find("MainVolumeText").GetComponent<Text>();
        settingsMusicVolume = settings.transform.Find("MusicVolumeText").GetComponent<Text>();
        settingsEffectsVolume = settings.transform.Find("EffectsVolumeText").GetComponent<Text>();
        settingsFullScreen = settings.transform.GetChild(8).GetChild(1).GetComponent<Text>();
        settingsResolution = settings.transform.Find("ResolutionText").GetComponent<Text>();
        settingsSaveResolution = settings.transform.GetChild(11).GetChild(0).GetComponent<Text>();
        settingsLanguage = settings.transform.Find("LanguageText").GetComponent<Text>();
        settingsClose = settings.transform.GetChild(14).GetChild(0).GetComponent<Text>();
        settingsConfirmText1 = confirmResolution.transform.Find("ConfirmationText").GetComponent<Text>();
        settingsConfirmText2 = confirmResolution.transform.Find("TimeText").GetComponent<Text>();
        settingsConfirm = confirmResolution.transform.GetChild(3).GetChild(0).GetComponent<Text>();
        battleSettingsTitle = battleSettings.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        battleSettingsPlayer = battleSettings.transform.Find("PlayerText").GetComponent<Text>();
        battleSettingsLifePoints = battleSettings.transform.Find("LifeLvl").GetComponent<Text>();
        battleSettingsLightPoints = battleSettings.transform.Find("LightLvl").GetComponent<Text>();
        battleSettingsSwordLevel = battleSettings.transform.Find("SwordLvl").GetComponent<Text>();
        battleSettingsShurikenLevel = battleSettings.transform.Find("ShurikenLvl").GetComponent<Text>();
        battleSettingsCompanions = battleSettings.transform.Find("CompanionText").GetComponent<Text>();
        battleSettingsAdventurerLevel = battleSettings.transform.Find("AdventurerText").GetComponent<Text>();
        battleSettingsWizardLevel = battleSettings.transform.Find("WizardText").GetComponent<Text>();
        battleSettingsEnemy1 = battleSettings.transform.Find("Enemy1Text").GetComponent<Text>();
        battleSettingsEnemy2 = battleSettings.transform.Find("Enemy2Text").GetComponent<Text>();
        battleSettingsEnemy3 = battleSettings.transform.Find("Enemy3Text").GetComponent<Text>();
        battleSettingsEnemy4 = battleSettings.transform.Find("Enemy4Text").GetComponent<Text>();
        battleSettingsExplanationText = battleSettings.transform.Find("ExplanationText").GetComponent<Text>();
        battleSettingsSave = battleSettings.transform.GetChild(25).GetChild(0).GetComponent<Text>();
        howToPlayTitle = howToPlay.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        howToPlayExplanation1 = howToPlay.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        howToPlayExplanation2 = howToPlay.transform.GetChild(3).GetChild(0).GetComponent<Text>();
        howToPlayExplanation3 = howToPlay.transform.GetChild(4).GetChild(0).GetComponent<Text>();
        howToPlayExplanation4 = howToPlay.transform.GetChild(5).GetChild(0).GetComponent<Text>();
        howToPlayExplanation5 = howToPlay.transform.GetChild(6).GetChild(0).GetComponent<Text>();
        howToPlayExplanation6 = howToPlay.transform.GetChild(7).GetChild(0).GetComponent<Text>();
        howToPlayPrev = howToPlay.transform.GetChild(8).GetChild(0).GetComponent<Text>();
        howToPlayNext = howToPlay.transform.GetChild(9).GetChild(0).GetComponent<Text>();
        howToPlayClose = howToPlay.transform.GetChild(10).GetChild(0).GetComponent<Text>();
        //We change the text depending on the selected language
        if(PlayerPrefs.GetInt("Language") == 1)
        {
            mainMenuStart.text = "Play";
            mainMenuSettings.text = "Settings";
            mainMenuBattleSetting.text = "Battle settings";
            mainMenuHowToPlay.text = "How to play";
            mainMenuExit.text = "Exit";
            settingsTitle.text = "Settings";
            settingsMasterVolume.text = "Master volume:";
            settingsMusicVolume.text = "Music volume:";
            settingsEffectsVolume.text = "Effects volume:";
            settingsFullScreen.text = "Full screen:";
            settingsResolution.text = "Resolution:";
            settingsSaveResolution.text = "Save resolution";
            settingsLanguage.text = "Language:";
            settingsClose.text = "Close";
            settingsConfirmText1.text = "Confirm the changes if you can see this window correctly.";
            settingsConfirmText2.text = "The changes will revert in";
            settingsConfirm.text = "Confirm";
            battleSettingsTitle.text = "Battle settings";
            battleSettingsPlayer.text = "Player:";
            battleSettingsLifePoints.text = "Life points:";
            battleSettingsLightPoints.text = "Light points:";
            battleSettingsSwordLevel.text = "Sword level:";
            battleSettingsShurikenLevel.text = "Shuriken level:";
            battleSettingsCompanions.text = "Companions:";
            battleSettingsAdventurerLevel.text = "Adventurer level:";
            battleSettingsWizardLevel.text = "Wizard level:";
            battleSettingsEnemy1.text = "Enemy 1:";
            enemy1.options.Clear();
            enemy1.options.Add(new Dropdown.OptionData("Bandit"));
            enemy1.options.Add(new Dropdown.OptionData("Evil Wizard"));
            enemy1.options.Add(new Dropdown.OptionData("King"));
            battleSettingsEnemy2.text = "Enemy 2:";
            enemy2.options.Clear();
            enemy2.options.Add(new Dropdown.OptionData("None"));
            enemy2.options.Add(new Dropdown.OptionData("Bandit"));
            enemy2.options.Add(new Dropdown.OptionData("Evil Wizard"));
            enemy2.options.Add(new Dropdown.OptionData("King"));
            battleSettingsEnemy3.text = "Enemy 3:";
            enemy3.options.Clear();
            enemy3.options.Add(new Dropdown.OptionData("None"));
            enemy3.options.Add(new Dropdown.OptionData("Bandit"));
            enemy3.options.Add(new Dropdown.OptionData("Evil Wizard"));
            enemy3.options.Add(new Dropdown.OptionData("King"));
            battleSettingsEnemy4.text = "Enemy 4:";
            enemy4.options.Clear();
            enemy4.options.Add(new Dropdown.OptionData("None"));
            enemy4.options.Add(new Dropdown.OptionData("Bandit"));
            enemy4.options.Add(new Dropdown.OptionData("Evil Wizard"));
            enemy4.options.Add(new Dropdown.OptionData("King"));
            battleSettingsExplanationText.text = "Change the battle settings.";
            battleSettingsSave.text = "Save";
            howToPlayTitle.text = "How to play";
            howToPlayExplanation1.text = "Project soul is a turn based RPG where you’ll need to do action commands every time you attack or be attacked. Each attack has their specific action command, so read the little explanation of the attack before starting the attack. On the other hand, the defend button is always the same, the “X” key, the only thing that changes is the timing.";
            howToPlayExplanation2.text = "Looking at the interface you will see the party stats. You can see the player’s and the active party member’s life points, party’s light points and the souls. You will need the light points to do some attacks. The souls will be spent when you do special attacks and will regenerate when you damage the enemy with normal attacks.";
            howToPlayExplanation3.text = "You can also see the actual XP, the coins, useless in this demo, and the XP gained in this battle. When you arrive 100 XP points you will level up, upgrading your life points, light points or gem points, useless in this demo.";
            howToPlayExplanation4.text = "Your team has 3 members: the protagonist, a warrior that can attack using her sword, for grounded enemies only, shurikens and magic, also known as the player; an adventurer, that can attack using their sword or bow and can tell you the life points and important things about your adversary; and the wizard, that can attack using his powerful magic or use it to protect the player, tanking all the damage.";
            howToPlayExplanation5.text = "All the team members can use objects, to heal wounded allies, even dead ones using the correct object, or to increase your light points, or do other actions: change companion, defend, gaining one defence point on the next turn, or flee the battle.";
            howToPlayExplanation6.text = "You can fight against 3 different enemies: the bandit, a ground enemy that will hit you with their sword, the evil wizard, a flying enemy that will try to burn you using their magical powers, and the king, a boss that will hit you twice with his mace or use his teleportation powers to do a powerful area attack, watch him carefully to know what attack he will do.";
            howToPlayPrev.text = "Prev";
            howToPlayNext.text = "Next";
            howToPlayClose.text = "Close";
        }
        else if(PlayerPrefs.GetInt("Language") == 2)
        {
            mainMenuStart.text = "Jugar";
            mainMenuSettings.text = "Ajustes";
            mainMenuBattleSetting.text = "Ajustes de combate";
            mainMenuHowToPlay.text = "Cómo jugar";
            mainMenuExit.text = "Salir";
            settingsTitle.text = "Ajustes";
            settingsMasterVolume.text = "Volumen maestro:";
            settingsMusicVolume.text = "Volumen de la música:";
            settingsEffectsVolume.text = "Volumen de los efectos:";
            settingsFullScreen.text = "Pantalla completa:";
            settingsResolution.text = "Resolución:";
            settingsSaveResolution.text = "Guardar resolución";
            settingsLanguage.text = "Idioma:";
            settingsClose.text = "Cerrar";
            settingsConfirmText1.text = "Confirma los cambios si ves esta ventana correctamente.";
            settingsConfirmText2.text = "Los cambios se revertirán en";
            settingsConfirm.text = "Confirmar";
            battleSettingsTitle.text = "Ajustes de batalla";
            battleSettingsPlayer.text = "Jugador:";
            battleSettingsLifePoints.text = "Puntos de vida:";
            battleSettingsLightPoints.text = "Puntos de luz:";
            battleSettingsSwordLevel.text = "Nivel de la espada:";
            battleSettingsShurikenLevel.text = "Nivel del shuriken:";
            battleSettingsCompanions.text = "Compañeros:";
            battleSettingsAdventurerLevel.text = "Nivel del aventurero:";
            battleSettingsWizardLevel.text = "Nivel del mago:";
            battleSettingsEnemy1.text = "Enemigo 1:";
            enemy1.options.Clear();
            enemy1.options.Add(new Dropdown.OptionData("Bandido"));
            enemy1.options.Add(new Dropdown.OptionData("Mago malvado"));
            enemy1.options.Add(new Dropdown.OptionData("Rey"));
            battleSettingsEnemy2.text = "Enemigo 2:";
            enemy2.options.Clear();
            enemy2.options.Add(new Dropdown.OptionData("Ninguno"));
            enemy2.options.Add(new Dropdown.OptionData("Bandido"));
            enemy2.options.Add(new Dropdown.OptionData("Mago malvado"));
            enemy2.options.Add(new Dropdown.OptionData("Rey"));
            battleSettingsEnemy3.text = "Enemigo 3:";
            enemy3.options.Clear();
            enemy3.options.Add(new Dropdown.OptionData("Ninguno"));
            enemy3.options.Add(new Dropdown.OptionData("Bandido"));
            enemy3.options.Add(new Dropdown.OptionData("Mago malvado"));
            enemy3.options.Add(new Dropdown.OptionData("Rey"));
            battleSettingsEnemy4.text = "Enemigo 4:";
            enemy4.options.Clear();
            enemy4.options.Add(new Dropdown.OptionData("Ninguno"));
            enemy4.options.Add(new Dropdown.OptionData("Bandido"));
            enemy4.options.Add(new Dropdown.OptionData("Mago malvado"));
            enemy4.options.Add(new Dropdown.OptionData("Rey"));
            battleSettingsExplanationText.text = "Cambia los ajustes de batalla.";
            battleSettingsSave.text = "Guardar";
            howToPlayTitle.text = "Cómo jugar";
            howToPlayExplanation1.text = "Project soul es un RPG por turnos donde tendrás que hacer comandos de acción cada vez que ataques o seas atacado. Cada ataque tiene su comando de acción propio, así que lee la pequeña explicación del ataque antes de atacar. Por otro lado, el botón de defensa es siempre el mismo, la tecla “X”, lo único que cambia es el momento en el que se pulsa.";
            howToPlayExplanation2.text = "Mirando a la interfaz verás las estadísticas de tu grupo. Puedes ver la vida del jugador y del compañero activo, los puntos de luz del equipo y las almas. Necesitarás los puntos de luz para usar algunos ataques. Las almas serán utilizadas cuando hagas ataques especiales y se regenerarán cuando dañes al enemigo con ataques normales.";
            howToPlayExplanation3.text = "También puedes ver la EXP actual, las monedas, inútiles en esta demo, y la EXP ganada en este combate. Cuando llegues a 100 puntos de EXP subirás de nivel, mejorando tus puntos de vida, puntos de luz o puntos de gema, inútiles en esta demo.";
            howToPlayExplanation4.text = "Tu equipo tiene tres participantes: la protagonista, una guerrera que puede atacar usando su espada, solo contra enemigos en el suelo, sus shurikens y su magia, también conocida como la jugadora; un aventurero, que puede atacar usando su espada o su arco y que puede decirte los puntos de vida y datos importantes de tu adversario; y el mago, que puede atacar usando su poderosa magia o usarla para proteger al jugador, tanqueando todo el daño.";
            howToPlayExplanation5.text = "Todos los miembros del equipo pueden usar objetos, para curar aliados heridos, incluso los muertos con el objeto adecuado, o para incrementar tus puntos de luz, o hacer otras acciones: cambiar de compañero, defenderse, ganando un punto de defensa en el siguiente turno, o huir de la pelea.";
            howToPlayExplanation6.text = "Puedes pelear contra 3 enemigos diferentes: el bandido, un enemigo que está en el suelo que te atacará con su espada, el mago malvado, un enemigo volador que te intentará quemar usando su magia, y el rey, un poderoso jefe que te atacará dos veces usando su maza o que usará sus poderes de teleportación para hacer un poderoso ataque en área, vigílalo bien para saber que ataque hará.";
            howToPlayPrev.text = "Prev";
            howToPlayNext.text = "Sig";
            howToPlayClose.text = "Cerrar ";
        }
        else
        {
            mainMenuStart.text = "Jolastu";
            mainMenuSettings.text = "Ezarpenak";
            mainMenuBattleSetting.text = "Borroka ezarpenak";
            mainMenuHowToPlay.text = "Nola jolastu";
            mainMenuExit.text = "Irten";
            settingsTitle.text = "Ezarpenak";
            settingsMasterVolume.text = "Bolumen nagusia:";
            settingsMusicVolume.text = "Musikaren bolumena:";
            settingsEffectsVolume.text = "Efektuen bolumena:";
            settingsFullScreen.text = "Pantaila osoa:";
            settingsResolution.text = "Erresoluzioa:";
            settingsSaveResolution.text = "Erresoluzioa gorde";
            settingsLanguage.text = "Hizkuntza:";
            settingsClose.text = "Itxi";
            settingsConfirmText1.text = "Aldaketak konfirmatu leiho hau ondo ikusten baduzu.";
            settingsConfirmText2.text = "Aldaketak desegingo dira";
            settingsConfirm.text = "Konfirmatu";
            battleSettingsTitle.text = "Borroka ezarpenak";
            battleSettingsPlayer.text = "Jokalaria:";
            battleSettingsLifePoints.text = "Bizitza puntuak:";
            battleSettingsLightPoints.text = "Argi puntuak:";
            battleSettingsSwordLevel.text = "Ezpataren nibela:";
            battleSettingsShurikenLevel.text = "Shurikenaren nibela:";
            battleSettingsCompanions.text = "Taldekideak:";
            battleSettingsAdventurerLevel.text = "Abenturazalearen nibela:";
            battleSettingsWizardLevel.text = "Magoaren nibela:";
            battleSettingsEnemy1.text = "1. etsaia:";
            enemy1.options.Clear();
            enemy1.options.Add(new Dropdown.OptionData("Bidelapurra"));
            enemy1.options.Add(new Dropdown.OptionData("Mago gaiztoa"));
            enemy1.options.Add(new Dropdown.OptionData("Erregea"));
            battleSettingsEnemy2.text = "2. etsaia:";
            enemy2.options.Clear();
            enemy2.options.Add(new Dropdown.OptionData("Bat ere ez"));
            enemy2.options.Add(new Dropdown.OptionData("Bidelapurra"));
            enemy2.options.Add(new Dropdown.OptionData("Mago gaiztoa"));
            enemy2.options.Add(new Dropdown.OptionData("Erregea"));
            battleSettingsEnemy3.text = "3. etsaia:";
            enemy3.options.Clear();
            enemy3.options.Add(new Dropdown.OptionData("Bat ere ez"));
            enemy3.options.Add(new Dropdown.OptionData("Bidelapurra"));
            enemy3.options.Add(new Dropdown.OptionData("Mago gaiztoa"));
            enemy3.options.Add(new Dropdown.OptionData("Erregea"));
            battleSettingsEnemy4.text = "4. etsaia:";
            enemy4.options.Clear();
            enemy4.options.Add(new Dropdown.OptionData("Bat ere ez"));
            enemy4.options.Add(new Dropdown.OptionData("Bidelapurra"));
            enemy4.options.Add(new Dropdown.OptionData("Mago gaiztoa"));
            enemy4.options.Add(new Dropdown.OptionData("Erregea"));
            battleSettingsExplanationText.text = "Borroka ezarpenak aldatu.";
            battleSettingsSave.text = "Gorde";
            howToPlayTitle.text = "Nola jolastu";
            howToPlayExplanation1.text = "Project soul turnoetan oinarritutako RPG bat da non akzio komandoak egin beharko dituzu atakatzen duzun edo atakatua zaren bakoitzean. Atake bakoitzak bere akzio komandoa dauka, beraz ondo irakurri atakearen esplikazio motza atakatu baino lehen. Beste aldetik, defentsa botoia beti da berdina, “X” tekla, aldatzen den gauza bakarra pultsatu behar den momentua da.";
            howToPlayExplanation2.text = "Interfazea begiratuz zure taldearen estatistikak ikusiko dituzu. Bertan jokalariaren eta borrokan dagoen taldekidearen bizitza puntuak, argi puntuak eta arimak ikus ditzakezu. Argi puntuak atake batzuetarako beharko dituzu. Arimak atake espezialak erabiltzerakoan gastatuko dira eta atake normalekin etsaiei min egiterakoan beteko dira.";
            howToPlayExplanation3.text = "Bertan momentuko EXPa, monetak, erabilezinak demo onetan, eta borroka honetan irabazitako EXPa ikus dezakezu ere. 100 EXP puntu lortzerakoan nibela igoko duzu, zure bizi puntuak, argi puntuak edo gema puntuak, erabilezinak demo honetan, hobetzeko aukera lortuz.";
            howToPlayExplanation4.text = "Zure taldeak 3 taldekide ditu: protagonista, bere ezpatarekin, bakarrik lurrean dauden etsaiei, shurikenekin edo bere magia erabiliz borrokatzen duen gerlari bat, jokalariaz ere ezagutua; abenturazale bat, bere ezpata edo arkua erabiliz atakatzen duena eta etsaien bizitza puntuak eta datu garrantzitsuak esan ahal dizkizu; eta magoa, bere magia erabiliz atakatu ahal du edo hau erabili jokalaria defendatzeko, min guztia berak jasoz.";
            howToPlayExplanation5.text = "Taldeko partaide guztiek erabili ditzakete objektuak, zauritutako lagunak sendatzeko, hilda daudenak ere objektu egokia erabiliz gero, edo argi puntuak igo, edo beste akzio batzuk egin: taldekidez aldatu, defendatu, defentsa puntu bat irabaziz hurrengo turnoan, edo borrokatik ihes egin.";
            howToPlayExplanation6.text = "3 etsai desberdinekin borrokatu dezakezu: bidelapurra, lurrean dagoen etsai bat bere ezpatarekin eraso egingo dizuna, mago gaiztoa, etsai hegalari bat bere magia erabiliz zu erretzen saiatuko dena, eta erregea, jefe boteretsu bat bi aldiz atakatuko zaituena bere maza erabiliz edo bere teleportazio botereak erabiliko dituena area atake indartsu bat egiteko, ondo bigila ezazu zer atake egingo duen jakiteko.";
            howToPlayPrev.text = "Aur";
            howToPlayNext.text = "Hur";
            howToPlayClose.text = "Itxi";
        }

        effectsSource = GameObject.Find("EffectsSource").GetComponent<AudioSource>();
        //We initialize the settings
        masterSlider.value = PlayerPrefs.GetFloat("Master");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        effectsSlider.value = PlayerPrefs.GetFloat("Effects");
        fullscreen.isOn = (PlayerPrefs.GetInt("FullScreen") == 1);
        if (PlayerPrefs.GetInt("Resolutiony") == 360) resolution.value = 0;
        else if (PlayerPrefs.GetInt("Resolutiony") == 480) resolution.value = 1;
        else if (PlayerPrefs.GetInt("Resolutiony") == 720) resolution.value = 2;
        else if (PlayerPrefs.GetInt("Resolutiony") == 1080) resolution.value = 3;
        else if (PlayerPrefs.GetInt("Resolutiony") == 1440) resolution.value = 4;
        else if (PlayerPrefs.GetInt("Resolutiony") == 2160) resolution.value = 5;
        confirmTime = -1.0f;
        //We initialize the battle settings
        lifeLvl.value = PlayerPrefs.GetInt("PlayerHeartLvl");
        lightLvl.value = PlayerPrefs.GetInt("PlayerLightLvl");
        adventurerLvl.value = PlayerPrefs.GetInt("AdventurerLvl") - 1;
        wizardLvl.value = PlayerPrefs.GetInt("WizardLvl") - 1;
        swordLvl.value = PlayerPrefs.GetInt("SwordLvl") - 1;
        shurikenLvl.value = PlayerPrefs.GetInt("ShurikenLvl") - 1;
        enemy1.value = PlayerPrefs.GetInt("Enemy1");
        enemy2.value = PlayerPrefs.GetInt("Enemy2");
        enemy3.value = PlayerPrefs.GetInt("Enemy3");
        enemy4.value = PlayerPrefs.GetInt("Enemy4");
        language.value = PlayerPrefs.GetInt("Language")-1;
        settings.SetActive(false);
        battleSettings.SetActive(false);
        confirmResolution.SetActive(false);
        howToPlay.SetActive(false);
        explanation = 1;
    }


    void Update()
    {
        if(confirmTime != -1.0f)
        {
            confirmTimeNumb.text = (5 - (int)(Time.fixedTime - confirmTime)).ToString();
            if ((Time.fixedTime - confirmTime) > 5.0f)
            {
                Screen.SetResolution(PlayerPrefs.GetInt("Resolutionx"), PlayerPrefs.GetInt("Resolutiony"), PlayerPrefs.GetInt("FullScreen") == 1);
                fullscreen.isOn = (PlayerPrefs.GetInt("FullScreen") == 1);
                if (PlayerPrefs.GetInt("Resolutiony") == 360) resolution.value = 0;
                else if (PlayerPrefs.GetInt("Resolutiony") == 480) resolution.value = 1;
                else if (PlayerPrefs.GetInt("Resolutiony") == 720) resolution.value = 2;
                else if (PlayerPrefs.GetInt("Resolutiony") == 1080) resolution.value = 3;
                else if (PlayerPrefs.GetInt("Resolutiony") == 1440) resolution.value = 4;
                else if (PlayerPrefs.GetInt("Resolutiony") == 2160) resolution.value = 5;
                confirmResolution.SetActive(false);
                settings.SetActive(true);
                confirmTime = -1.0f;
                saveResolutionButton.interactable = false;
            }
        }
    }

    //Function to start the game
    public void StartGame()
    {
        effectsSource.Play();
        SceneManager.LoadScene(1);
    }

    //Function to open the battle settings
    public void OpenBattleSettings()
    {
        effectsSource.Play();
        mainMenu.SetActive(false);
        battleSettings.SetActive(true);
    }

    //Function to make the effect play
    public void UIEffect()
    {
        if(!mainMenu.activeSelf) effectsSource.Play();
    }

    //Function to change the language
    public void ChangeLanguage()
    {
        if (!mainMenu.activeSelf) effectsSource.Play();
        PlayerPrefs.SetInt("Language", language.value+1);
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            mainMenuStart.text = "Play";
            mainMenuSettings.text = "Settings";
            mainMenuBattleSetting.text = "Battle settings";
            mainMenuHowToPlay.text = "How to play";
            mainMenuExit.text = "Exit";
            settingsTitle.text = "Settings";
            settingsMasterVolume.text = "Master volume:";
            settingsMusicVolume.text = "Music volume:";
            settingsEffectsVolume.text = "Effects volume:";
            settingsFullScreen.text = "Full screen:";
            settingsResolution.text = "Resolution:";
            settingsSaveResolution.text = "Save resolution";
            settingsLanguage.text = "Language:";
            settingsClose.text = "Close";
            settingsConfirmText1.text = "Confirm the changes if you can see this window correctly.";
            settingsConfirmText2.text = "The changes will revert in";
            settingsConfirm.text = "Confirm";
            battleSettingsTitle.text = "Battle settings";
            battleSettingsPlayer.text = "Player:";
            battleSettingsLifePoints.text = "Life points:";
            battleSettingsLightPoints.text = "Light points:";
            battleSettingsSwordLevel.text = "Sword level:";
            battleSettingsShurikenLevel.text = "Shuriken level:";
            battleSettingsCompanions.text = "Companions:";
            battleSettingsAdventurerLevel.text = "Adventurer level:";
            battleSettingsWizardLevel.text = "Wizard level:";
            battleSettingsEnemy1.text = "Enemy 1:";
            enemy1.options.Clear();
            enemy1.options.Add(new Dropdown.OptionData("Bandit"));
            enemy1.options.Add(new Dropdown.OptionData("Evil Wizard"));
            enemy1.options.Add(new Dropdown.OptionData("King"));
            battleSettingsEnemy2.text = "Enemy 2:";
            enemy2.options.Clear();
            enemy2.options.Add(new Dropdown.OptionData("None"));
            enemy2.options.Add(new Dropdown.OptionData("Bandit"));
            enemy2.options.Add(new Dropdown.OptionData("Evil Wizard"));
            enemy2.options.Add(new Dropdown.OptionData("King"));
            battleSettingsEnemy3.text = "Enemy 3:";
            enemy3.options.Clear();
            enemy3.options.Add(new Dropdown.OptionData("None"));
            enemy3.options.Add(new Dropdown.OptionData("Bandit"));
            enemy3.options.Add(new Dropdown.OptionData("Evil Wizard"));
            enemy3.options.Add(new Dropdown.OptionData("King"));
            battleSettingsEnemy4.text = "Enemy 4:";
            enemy4.options.Clear();
            enemy4.options.Add(new Dropdown.OptionData("None"));
            enemy4.options.Add(new Dropdown.OptionData("Bandit"));
            enemy4.options.Add(new Dropdown.OptionData("Evil Wizard"));
            enemy4.options.Add(new Dropdown.OptionData("King"));
            battleSettingsExplanationText.text = "Change the battle settings.";
            battleSettingsSave.text = "Save";
            howToPlayTitle.text = "How to play";
            howToPlayExplanation1.text = "Project soul is a turn based RPG where you’ll need to do action commands every time you attack or be attacked. Each attack has their specific action command, so read the little explanation of the attack before starting the attack. On the other hand, the defend button is always the same, the “X” key, the only thing that changes is the timing.";
            howToPlayExplanation2.text = "Looking at the interface you will see the party stats. You can see the player’s and the active party member’s life points, party’s light points and the souls. You will need the light points to do some attacks. The souls will be spent when you do special attacks and will regenerate when you damage the enemy with normal attacks.";
            howToPlayExplanation3.text = "You can also see the actual XP, the coins, useless in this demo, and the XP gained in this battle. When you arrive 100 XP points you will level up, upgrading your life points, light points or gem points, useless in this demo.";
            howToPlayExplanation4.text = "Your team has 3 members: the protagonist, a warrior that can attack using her sword, for grounded enemies only, shurikens and magic, also known as the player; an adventurer, that can attack using their sword or bow and can tell you the life points and important things about your adversary; and the wizard, that can attack using his powerful magic or use it to protect the player, tanking all the damage.";
            howToPlayExplanation5.text = "All the team members can use objects, to heal wounded allies, even dead ones using the correct object, or to increase your light points, or do other actions: change companion, defend, gaining one defence point on the next turn, or flee the battle.";
            howToPlayExplanation6.text = "You can fight against 3 different enemies: the bandit, a ground enemy that will hit you with their sword, the evil wizard, a flying enemy that will try to burn you using their magical powers, and the king, a boss that will hit you twice with his mace or use his teleportation powers to do a powerful area attack, watch him carefully to know what attack he will do.";
            howToPlayPrev.text = "Prev";
            howToPlayNext.text = "Next";
            howToPlayClose.text = "Close";
        }
        else if (PlayerPrefs.GetInt("Language") == 2)
        {
            mainMenuStart.text = "Jugar";
            mainMenuSettings.text = "Ajustes";
            mainMenuBattleSetting.text = "Ajustes de combate";
            mainMenuHowToPlay.text = "Cómo jugar";
            mainMenuExit.text = "Salir";
            settingsTitle.text = "Ajustes";
            settingsMasterVolume.text = "Volumen maestro:";
            settingsMusicVolume.text = "Volumen de la música:";
            settingsEffectsVolume.text = "Volumen de los efectos:";
            settingsFullScreen.text = "Pantalla completa:";
            settingsResolution.text = "Resolución:";
            settingsSaveResolution.text = "Guardar resolución";
            settingsLanguage.text = "Idioma:";
            settingsClose.text = "Cerrar";
            settingsConfirmText1.text = "Confirma los cambios si ves esta ventana correctamente.";
            settingsConfirmText2.text = "Los cambios se revertirán en";
            settingsConfirm.text = "Confirmar";
            battleSettingsTitle.text = "Ajustes de batalla";
            battleSettingsPlayer.text = "Jugador:";
            battleSettingsLifePoints.text = "Puntos de vida:";
            battleSettingsLightPoints.text = "Puntos de luz:";
            battleSettingsSwordLevel.text = "Nivel de la espada:";
            battleSettingsShurikenLevel.text = "Nivel del shuriken:";
            battleSettingsCompanions.text = "Compañeros:";
            battleSettingsAdventurerLevel.text = "Nivel del aventurero:";
            battleSettingsWizardLevel.text = "Nivel del mago:";
            battleSettingsEnemy1.text = "Enemigo 1:";
            enemy1.options.Clear();
            enemy1.options.Add(new Dropdown.OptionData("Bandido"));
            enemy1.options.Add(new Dropdown.OptionData("Mago malvado"));
            enemy1.options.Add(new Dropdown.OptionData("Rey"));
            battleSettingsEnemy2.text = "Enemigo 2:";
            enemy2.options.Clear();
            enemy2.options.Add(new Dropdown.OptionData("Ninguno"));
            enemy2.options.Add(new Dropdown.OptionData("Bandido"));
            enemy2.options.Add(new Dropdown.OptionData("Mago malvado"));
            enemy2.options.Add(new Dropdown.OptionData("Rey"));
            battleSettingsEnemy3.text = "Enemigo 3:";
            enemy3.options.Clear();
            enemy3.options.Add(new Dropdown.OptionData("Ninguno"));
            enemy3.options.Add(new Dropdown.OptionData("Bandido"));
            enemy3.options.Add(new Dropdown.OptionData("Mago malvado"));
            enemy3.options.Add(new Dropdown.OptionData("Rey"));
            battleSettingsEnemy4.text = "Enemigo 4:";
            enemy4.options.Clear();
            enemy4.options.Add(new Dropdown.OptionData("Ninguno"));
            enemy4.options.Add(new Dropdown.OptionData("Bandido"));
            enemy4.options.Add(new Dropdown.OptionData("Mago malvado"));
            enemy4.options.Add(new Dropdown.OptionData("Rey"));
            battleSettingsExplanationText.text = "Cambia los ajustes de batalla.";
            battleSettingsSave.text = "Guardar";
            howToPlayTitle.text = "Cómo jugar";
            howToPlayExplanation1.text = "Project soul es un RPG por turnos donde tendrás que hacer comandos de acción cada vez que ataques o seas atacado. Cada ataque tiene su comando de acción propio, así que lee la pequeña explicación del ataque antes de atacar. Por otro lado, el botón de defensa es siempre el mismo, la tecla “X”, lo único que cambia es el momento en el que se pulsa.";
            howToPlayExplanation2.text = "Mirando a la interfaz verás las estadísticas de tu grupo. Puedes ver la vida del jugador y del compañero activo, los puntos de luz del equipo y las almas. Necesitarás los puntos de luz para usar algunos ataques. Las almas serán utilizadas cuando hagas ataques especiales y se regenerarán cuando dañes al enemigo con ataques normales.";
            howToPlayExplanation3.text = "También puedes ver la EXP actual, las monedas, inútiles en esta demo, y la EXP ganada en este combate. Cuando llegues a 100 puntos de EXP subirás de nivel, mejorando tus puntos de vida, puntos de luz o puntos de gema, inútiles en esta demo.";
            howToPlayExplanation4.text = "Tu equipo tiene tres participantes: la protagonista, una guerrera que puede atacar usando su espada, solo contra enemigos en el suelo, sus shurikens y su magia, también conocida como la jugadora; un aventurero, que puede atacar usando su espada o su arco y que puede decirte los puntos de vida y datos importantes de tu adversario; y el mago, que puede atacar usando su poderosa magia o usarla para proteger al jugador, tanqueando todo el daño.";
            howToPlayExplanation5.text = "Todos los miembros del equipo pueden usar objetos, para curar aliados heridos, incluso los muertos con el objeto adecuado, o para incrementar tus puntos de luz, o hacer otras acciones: cambiar de compañero, defenderse, ganando un punto de defensa en el siguiente turno, o huir de la pelea.";
            howToPlayExplanation6.text = "Puedes pelear contra 3 enemigos diferentes: el bandido, un enemigo que está en el suelo que te atacará con su espada, el mago malvado, un enemigo volador que te intentará quemar usando su magia, y el rey, un poderoso jefe que te atacará dos veces usando su maza o que usará sus poderes de teleportación para hacer un poderoso ataque en área, vigílalo bien para saber que ataque hará.";
            howToPlayPrev.text = "Prev";
            howToPlayNext.text = "Sig";
            howToPlayClose.text = "Cerrar ";
        }
        else
        {
            mainMenuStart.text = "Jolastu";
            mainMenuSettings.text = "Ezarpenak";
            mainMenuBattleSetting.text = "Borroka ezarpenak";
            mainMenuHowToPlay.text = "Nola jolastu";
            mainMenuExit.text = "Irten";
            settingsTitle.text = "Ezarpenak";
            settingsMasterVolume.text = "Bolumen nagusia:";
            settingsMusicVolume.text = "Musikaren bolumena:";
            settingsEffectsVolume.text = "Efektuen bolumena:";
            settingsFullScreen.text = "Pantaila osoa:";
            settingsResolution.text = "Erresoluzioa:";
            settingsSaveResolution.text = "Erresoluzioa gorde";
            settingsLanguage.text = "Hizkuntza:";
            settingsClose.text = "Itxi";
            settingsConfirmText1.text = "Aldaketak konfirmatu leiho hau ondo ikusten baduzu.";
            settingsConfirmText2.text = "Aldaketak desegingo dira";
            settingsConfirm.text = "Konfirmatu";
            battleSettingsTitle.text = "Borroka ezarpenak";
            battleSettingsPlayer.text = "Jokalaria:";
            battleSettingsLifePoints.text = "Bizitza puntuak:";
            battleSettingsLightPoints.text = "Argi puntuak:";
            battleSettingsSwordLevel.text = "Ezpataren nibela:";
            battleSettingsShurikenLevel.text = "Shurikenaren nibela:";
            battleSettingsCompanions.text = "Taldekideak:";
            battleSettingsAdventurerLevel.text = "Abenturazalearen nibela:";
            battleSettingsWizardLevel.text = "Magoaren nibela:";
            battleSettingsEnemy1.text = "1. etsaia:";
            enemy1.options.Clear();
            enemy1.options.Add(new Dropdown.OptionData("Bidelapurra"));
            enemy1.options.Add(new Dropdown.OptionData("Mago gaiztoa"));
            enemy1.options.Add(new Dropdown.OptionData("Erregea"));
            battleSettingsEnemy2.text = "2. etsaia:";
            enemy2.options.Clear();
            enemy2.options.Add(new Dropdown.OptionData("Bat ere ez"));
            enemy2.options.Add(new Dropdown.OptionData("Bidelapurra"));
            enemy2.options.Add(new Dropdown.OptionData("Mago gaiztoa"));
            enemy2.options.Add(new Dropdown.OptionData("Erregea"));
            battleSettingsEnemy3.text = "3. etsaia:";
            enemy3.options.Clear();
            enemy3.options.Add(new Dropdown.OptionData("Bat ere ez"));
            enemy3.options.Add(new Dropdown.OptionData("Bidelapurra"));
            enemy3.options.Add(new Dropdown.OptionData("Mago gaiztoa"));
            enemy3.options.Add(new Dropdown.OptionData("Erregea"));
            battleSettingsEnemy4.text = "4. etsaia:";
            enemy4.options.Clear();
            enemy4.options.Add(new Dropdown.OptionData("Bat ere ez"));
            enemy4.options.Add(new Dropdown.OptionData("Bidelapurra"));
            enemy4.options.Add(new Dropdown.OptionData("Mago gaiztoa"));
            enemy4.options.Add(new Dropdown.OptionData("Erregea"));
            battleSettingsExplanationText.text = "Borroka ezarpenak aldatu.";
            battleSettingsSave.text = "Gorde";
            howToPlayTitle.text = "Nola jolastu";
            howToPlayExplanation1.text = "Project soul turnoetan oinarritutako RPG bat da non akzio komandoak egin beharko dituzu atakatzen duzun edo atakatua zaren bakoitzean. Atake bakoitzak bere akzio komandoa dauka, beraz ondo irakurri atakearen esplikazio motza atakatu baino lehen. Beste aldetik, defentsa botoia beti da berdina, “X” tekla, aldatzen den gauza bakarra pultsatu behar den momentua da.";
            howToPlayExplanation2.text = "Interfazea begiratuz zure taldearen estatistikak ikusiko dituzu. Bertan jokalariaren eta borrokan dagoen taldekidearen bizitza puntuak, argi puntuak eta arimak ikus ditzakezu. Argi puntuak atake batzuetarako beharko dituzu. Arimak atake espezialak erabiltzerakoan gastatuko dira eta atake normalekin etsaiei min egiterakoan beteko dira.";
            howToPlayExplanation3.text = "Bertan momentuko EXPa, monetak, erabilezinak demo onetan, eta borroka honetan irabazitako EXPa ikus dezakezu ere. 100 EXP puntu lortzerakoan nibela igoko duzu, zure bizi puntuak, argi puntuak edo gema puntuak, erabilezinak demo honetan, hobetzeko aukera lortuz.";
            howToPlayExplanation4.text = "Zure taldeak 3 taldekide ditu: protagonista, bere ezpatarekin, bakarrik lurrean dauden etsaiei, shurikenekin edo bere magia erabiliz borrokatzen duen gerlari bat, jokalariaz ere ezagutua; abenturazale bat, bere ezpata edo arkua erabiliz atakatzen duena eta etsaien bizitza puntuak eta datu garrantzitsuak esan ahal dizkizu; eta magoa, bere magia erabiliz atakatu ahal du edo hau erabili jokalaria defendatzeko, min guztia berak jasoz.";
            howToPlayExplanation5.text = "Taldeko partaide guztiek erabili ditzakete objektuak, zauritutako lagunak sendatzeko, hilda daudenak ere objektu egokia erabiliz gero, edo argi puntuak igo, edo beste akzio batzuk egin: taldekidez aldatu, defendatu, defentsa puntu bat irabaziz hurrengo turnoan, edo borrokatik ihes egin.";
            howToPlayExplanation6.text = "3 etsai desberdinekin borrokatu dezakezu: bidelapurra, lurrean dagoen etsai bat bere ezpatarekin eraso egingo dizuna, mago gaiztoa, etsai hegalari bat bere magia erabiliz zu erretzen saiatuko dena, eta erregea, jefe boteretsu bat bi aldiz atakatuko zaituena bere maza erabiliz edo bere teleportazio botereak erabiliko dituena area atake indartsu bat egiteko, ondo bigila ezazu zer atake egingo duen jakiteko.";
            howToPlayPrev.text = "Aur";
            howToPlayNext.text = "Hur";
            howToPlayClose.text = "Itxi";
        }
        enemy1.transform.GetChild(0).GetComponent<Text>().text = enemy1.options[enemy1.value].text;
        enemy2.transform.GetChild(0).GetComponent<Text>().text = enemy2.options[enemy2.value].text;
        enemy3.transform.GetChild(0).GetComponent<Text>().text = enemy3.options[enemy3.value].text;
        enemy4.transform.GetChild(0).GetComponent<Text>().text = enemy4.options[enemy4.value].text;
    }

    //Function to make active the enemy3 and enemy4 dropdowns
    public void ActivateEnemyDropdown()
    {
        if (!mainMenu.activeSelf) effectsSource.Play();
        if (enemy2.value > 0) enemy3.interactable = true;
        if (enemy3.value > 0) enemy4.interactable = true;
        if (enemy2.value == 0)
        {
            enemy3.value = 0;
            enemy3.interactable = false;
            enemy4.value = 0;
            enemy4.interactable = false;
        }
        if (enemy3.value == 0)
        {
            enemy4.value = 0;
            enemy4.interactable = false;
        }
    }

    //Function to open the settings
    public void OpenSettings()
    {
        effectsSource.Play();
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    //Function to close the settings
    public void CloseSettings()
    {
        effectsSource.Play();
        mainMenu.SetActive(true);
        settings.SetActive(false);
        fullscreen.isOn = (PlayerPrefs.GetInt("FullScreen") == 1);
        if (PlayerPrefs.GetInt("Resolutiony") == 360) resolution.value = 0;
        else if (PlayerPrefs.GetInt("Resolutiony") == 480) resolution.value = 1;
        else if (PlayerPrefs.GetInt("Resolutiony") == 720) resolution.value = 2;
        else if (PlayerPrefs.GetInt("Resolutiony") == 1080) resolution.value = 3;
        else if (PlayerPrefs.GetInt("Resolutiony") == 1440) resolution.value = 4;
        else if (PlayerPrefs.GetInt("Resolutiony") == 2160) resolution.value = 5;
    }

    //Function to make the save resolution button interactable
    public void ResolutionChanged()
    {
        if (!mainMenu.activeSelf && !confirmResolution.activeSelf) effectsSource.Play();
        if (fullscreen.isOn != (PlayerPrefs.GetInt("FullScreen") == 1))
        {
            saveResolutionButton.interactable = true;
        }
        else 
        {
            if (PlayerPrefs.GetInt("Resolutiony") == 360 && resolution.value == 0) 
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 480 && resolution.value == 1)
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 720 && resolution.value == 2)
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 1080 && resolution.value == 3)
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 1440 && resolution.value == 4)
            {
                saveResolutionButton.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Resolutiony") == 2160 && resolution.value == 5)
            {
                saveResolutionButton.interactable = false;
            }
            else
            {
                saveResolutionButton.interactable = true;
            }
        }
    }

    //Function to save the resolution settings
    public void SaveResolution()
    {
        effectsSource.Play();
        if (resolution.value == 0) Screen.SetResolution(640,360,fullscreen.isOn);
        else if (resolution.value == 1) Screen.SetResolution(854, 480, fullscreen.isOn);
        else if (resolution.value == 2) Screen.SetResolution(1280, 720, fullscreen.isOn);
        else if (resolution.value == 3) Screen.SetResolution(1920, 1080, fullscreen.isOn);
        else if (resolution.value == 4) Screen.SetResolution(2560, 1440, fullscreen.isOn);
        else if (resolution.value == 5) Screen.SetResolution(3840, 2160, fullscreen.isOn);
        confirmTime = Time.fixedTime;
        confirmResolution.SetActive(true);
    }
    //Function to confirm the resolution settings
    public void ConfirmResolution()
    {
        effectsSource.Play();
        if (resolution.value == 0)
        {
            PlayerPrefs.SetInt("Resolutionx", 640);
            PlayerPrefs.SetInt("Resolutiony", 360);
        }
        else if (resolution.value == 1)
        {
            PlayerPrefs.SetInt("Resolutionx", 854);
            PlayerPrefs.SetInt("Resolutiony", 480);
        }
        else if (resolution.value == 2)
        {
            PlayerPrefs.SetInt("Resolutionx", 1280);
            PlayerPrefs.SetInt("Resolutiony", 720);
        }
        else if (resolution.value == 3)
        {
            PlayerPrefs.SetInt("Resolutionx", 1920);
            PlayerPrefs.SetInt("Resolutiony", 1080);
        }
        else if (resolution.value == 4)
        {
            PlayerPrefs.SetInt("Resolutionx", 2560);
            PlayerPrefs.SetInt("Resolutiony", 1440);
        }
        else if (resolution.value == 5)
        {
            PlayerPrefs.SetInt("Resolutionx", 3840);
            PlayerPrefs.SetInt("Resolutiony", 2160);
        }
        if (fullscreen.isOn) PlayerPrefs.SetInt("FullScreen", 1);
        else PlayerPrefs.SetInt("FullScreen", 0);
        confirmTime = -1.0f;
        confirmResolution.SetActive(false); 
        saveResolutionButton.interactable = false;
    }

    //Function to change the explanation text
    public void ChangeExplanationText(int d)
    {
        if (PlayerPrefs.GetInt("Language") == 1)
        {
            if (d == 0) battleSettingsExplanationText.text = "Change the maximum life points of the player.";
            else if (d == 1) battleSettingsExplanationText.text = "Change the maximum light points of the player. You will need them to use some abilities.";
            else if (d == 2) battleSettingsExplanationText.text = "Change the sword level. More level equals more damage.";
            else if (d == 3) battleSettingsExplanationText.text = "Change the shuriken level. More level equals more damage.";
            else if (d == 4) battleSettingsExplanationText.text = "Change the level of the adventurer companion. He will gain life points, abilities and damage.";
            else if (d == 5) battleSettingsExplanationText.text = "Change the level of the wizard companion. He will gain life points, abilities and damage.";
            else if (d == 6) battleSettingsExplanationText.text = "Change the first enemy. You can choose between two normal enemies, a bandit and a wizard, and a boss, the king.";
            else if (d == 7) battleSettingsExplanationText.text = "Change the second enemy. You can choose between two normal enemies, a bandit and a wizard, and a boss, the king.";
            else if (d == 8) battleSettingsExplanationText.text = "Change the third enemy. You can choose between two normal enemies, a bandit and a wizard, and a boss, the king.";
            else if (d == 9) battleSettingsExplanationText.text = "Change the fourth enemy. You can choose between two normal enemies, a bandit and a wizard, and a boss, the king.";
            else if (d == 10) battleSettingsExplanationText.text = "Change the battle settings.";
        }
        else if(PlayerPrefs.GetInt("Language") == 2)
        {
            if (d == 0) battleSettingsExplanationText.text = "Cambia los puntos de vida máximos del jugador.";
            else if (d == 1) battleSettingsExplanationText.text = "Cambia los puntos de luz máximos del jugador. Los necesitaras para usar algunas habilidades.";
            else if (d == 2) battleSettingsExplanationText.text = "Cambia el nivel de la espada. Más niveles igual a más daño.";
            else if (d == 3) battleSettingsExplanationText.text = "Cambia el nivel del shuriken. Más niveles igual a más daño.";
            else if (d == 4) battleSettingsExplanationText.text = "Cambia el nivel del aventurero. Ganará puntos de vida, habilidades y daño. ";
            else if (d == 5) battleSettingsExplanationText.text = "Cambia el nivel del mago. Ganará puntos de vida, habilidades y daño.";
            else if (d == 6) battleSettingsExplanationText.text = "Cambia el primer enemigo. Puedes elegir entre dos enemigos normales, un bandido y un mago malvado, y un jefe, el rey. ";
            else if (d == 7) battleSettingsExplanationText.text = "Cambia el segundo enemigo. Puedes elegir entre dos enemigos normales, un bandido y un mago malvado, y un jefe, el rey.";
            else if (d == 8) battleSettingsExplanationText.text = "Cambia el tercer enemigo. Puedes elegir entre dos enemigos normales, un bandido y un mago malvado, y un jefe, el rey. ";
            else if (d == 9) battleSettingsExplanationText.text = "Cambia el cuarto enemigo. Puedes elegir entre dos enemigos normales, un bandido y un mago malvado, y un jefe, el rey.";
            else if (d == 10) battleSettingsExplanationText.text = "Cambia los ajustes de batalla.";
        }
        else
        {
            if (d == 0) battleSettingsExplanationText.text = "Jokalariaren bizitza puntuak aldatu.";
            else if (d == 1) battleSettingsExplanationText.text = "Jokalariaren argi puntuak aldatu. Abilitate batzuk erabiltzeko beharko dituzu.";
            else if (d == 2) battleSettingsExplanationText.text = "Ezpataren nibela aldatu. Nibel gehiago berdin min gehiago.";
            else if (d == 3) battleSettingsExplanationText.text = "Shurikenaren nibela aldatu. Nibel gehiago berdin min gehiago.";
            else if (d == 4) battleSettingsExplanationText.text = "Abenturazalearen nibela aldatu. Bizitza puntuak abilitateak eta mina irabaziko ditu. ";
            else if (d == 5) battleSettingsExplanationText.text = "Magoaren nibela aldatu. Bizitza puntuak abilitateak eta mina irabaziko ditu.";
            else if (d == 6) battleSettingsExplanationText.text = "Lehen etsaia aldatu. Bi etsai normal, bidelapurra eta mago gaiztoa, eta jefe bat, erregea, aukeratu ahal dituzu.";
            else if (d == 7) battleSettingsExplanationText.text = "Bigarren etsaia aldatu. Bi etsai normal, bidelapurra eta mago gaiztoa, eta jefe bat, erregea, aukeratu ahal dituzu.";
            else if (d == 8) battleSettingsExplanationText.text = "Hirugarren etsaia aldatu. Bi etsai normal, bidelapurra eta mago gaiztoa, eta jefe bat, erregea, aukeratu ahal dituzu.";
            else if (d == 9) battleSettingsExplanationText.text = "Laugarren etsaia aldatu. Bi etsai normal, bidelapurra eta mago gaiztoa, eta jefe bat, erregea, aukeratu ahal dituzu.";
            else if (d == 10) battleSettingsExplanationText.text = "Borroka ezarpenak aldatu.";
        }
    }

    //Function to close the battle settings
    public void CloseBattleSettings()
    {
        effectsSource.Play();
        PlayerPrefs.SetInt("PlayerHeartLvl", lifeLvl.value);
        PlayerPrefs.SetInt("PlayerLightLvl", lightLvl.value);
        PlayerPrefs.SetInt("PlayerLvl", 1 + PlayerPrefs.GetInt("PlayerHeartLvl") + PlayerPrefs.GetInt("PlayerLightLvl") + PlayerPrefs.GetInt("PlayerBadgeLvl"));
        PlayerPrefs.SetInt("PlayerCurrentHealth", 10 + lifeLvl.value*5);
        PlayerPrefs.SetInt("AdventurerLvl", adventurerLvl.value + 1); 
        PlayerPrefs.SetInt("AdventurerCurrentHealth", 10 + (adventurerLvl.value + 1) * 10);
        PlayerPrefs.SetInt("WizardLvl", wizardLvl.value + 1); 
        PlayerPrefs.SetInt("WizardCurrentHealth", 15 + (wizardLvl.value + 1) * 10);
        PlayerPrefs.SetInt("SwordLvl", swordLvl.value + 1); 
        PlayerPrefs.SetInt("ShurikenLvl", shurikenLvl.value + 1); 
        PlayerPrefs.SetInt("Enemy1", enemy1.value);
        PlayerPrefs.SetInt("Enemy2", enemy2.value);
        PlayerPrefs.SetInt("Enemy3", enemy3.value);
        PlayerPrefs.SetInt("Enemy4", enemy4.value);
        mainMenu.SetActive(true);
        battleSettings.SetActive(false);
    }

    //Function to open the how to play tutorial
    public void OpenHowToPlay()
    {
        effectsSource.Play();
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    //Function to close the how to play tutorial
    public void CloseHowToPlay()
    {
        effectsSource.Play();
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(false);
        explanation = 1;
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(true);
        howToPlay.transform.GetChild(8).GetComponent<Button>().interactable = false;
        howToPlay.transform.GetChild(9).GetComponent<Button>().interactable = true;
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void NextExplanation()
    {
        effectsSource.Play();
        howToPlay.transform.GetChild(1+explanation).gameObject.SetActive(false);
        explanation += 1;
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(true);
        if (explanation == 6) howToPlay.transform.GetChild(9).GetComponent<Button>().interactable = false;
        else howToPlay.transform.GetChild(9).GetComponent<Button>().interactable = true;
        howToPlay.transform.GetChild(8).GetComponent<Button>().interactable = true;
    }

    public void PrevExplanation()
    {
        effectsSource.Play();
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(false);
        explanation -= 1;
        howToPlay.transform.GetChild(1 + explanation).gameObject.SetActive(true);
        if (explanation == 1) howToPlay.transform.GetChild(8).GetComponent<Button>().interactable = false;
        else howToPlay.transform.GetChild(8).GetComponent<Button>().interactable = true;
        howToPlay.transform.GetChild(9).GetComponent<Button>().interactable = true;
    }


    //Function to close the game
    public void CloseGame()
    {
        effectsSource.Play();
        Debug.Log("Closing...");
        Application.Quit();
    }

}
