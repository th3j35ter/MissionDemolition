using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameMode
{
    idle,
    playing,
    levelEnd,
    gameOver
}

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S; // Private singleton

    [Header("Inscribed")]
    public Text uitLevel; // uitext_level text
    public Text uitShots; // uitext_shots text
    public Text bestShotsText;
    public Vector3 castlePos;
    public GameObject[] castles;
    public GameObject gameOverScreen;

    [Header("Dynamic")]
    public int level;
    public int levelMax;
    public int shotsTaken;
    public int bestShots;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        S = this;

        level = 0;
        shotsTaken = 0;
        levelMax = castles.Length;

        bestShots = PlayerPrefs.GetInt("BestShots", int.MaxValue);

        StartLevel();
        gameOverScreen.SetActive(false);
    }

    void StartLevel()
    {
        if(castle != null)
        {
            Destroy(castle);
        }

        Projectile.DESTROY_PROJECTILES();

        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;

        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;

        FollowCam.SWITCH_VIEW(FollowCam.eView.both);
    }

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;

        if (bestShots == int.MaxValue)
        {
            bestShotsText.text = "Best Shots: N/A";
        } 
        else
        {
            bestShotsText.text = "Best Shots: " + bestShots;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();

        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;

            FollowCam.SWITCH_VIEW(FollowCam.eView.both);

            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        level++;
        if(level >= levelMax)
        {
            CheckForNewRecord();
            ShowGameOverScreen();
            return;
        }

        StartLevel();
    }

    void CheckForNewRecord()
    {
        if(shotsTaken < bestShots)
        {
            bestShots = shotsTaken;
            PlayerPrefs.SetInt("BestShots", bestShots);
            PlayerPrefs.Save();
        }
    }

    void ShowGameOverScreen()
    {
        mode = GameMode.gameOver;
        gameOverScreen.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    static public void SHOT_FIRED()
    {
        S.shotsTaken++;
        PlayerPrefs.SetInt("ShotsFired", S.shotsTaken);
        PlayerPrefs.Save();
    }

    static public GameObject GET_CASTLE()
    {
        return S.castle;
    }
}
