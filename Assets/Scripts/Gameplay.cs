using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;

    public TMP_Text scoreText;
    public TMP_Text bestText;
    public TMP_Text ballText;
    public GameObject ballObject;

    public TMP_Text gameOver;
    public TMP_Text best2Text;
    public GameObject retryButton;
    public GameObject menuButton;

    private int score = 0;
    private int best = 0;
    public static int ball = 1;
    public static bool gameplay = false;


    //Innit
    private void Awake()
    {
        instance = this;
        best = PlayerPrefs.GetInt("best", best);
        ShowGameOverUI(false);
        NewGame();
    }

    //Game Over Buttons
    public void NewGame() { RestartLevel(true); }
    public void Menu() { SceneManager.LoadScene(0); }


    public void RestartLevel(bool newGame = false)
    {
        Debug.Log(ball.ToString());

        if (score > best)
            best = score;
        score = 0;

        if (newGame)
        {
            ball = 1;
            ShowGameOverUI(false);
        }
        else
        {
            ball++;
        }

        UpdateUI();


        if (ball == 4)
        {
            Debug.Log("Game Over");
            PlayerPrefs.SetInt("best", best);
            ShowGameOverUI(true);
            Sounds.instance.StopAll();
            Sounds.instance.GameOver();
            gameplay = false;


            //Scene; n, just show game over and best and balls falling. button restart, menu
        }
        else if(ball<4) { BallStartPosition(); }



    }

    

    public void AddPoints(int i) {
        score += i;
        Sounds.instance.Barrel();
        UpdateUI();
    }

    private void BallStartPosition() {
        try { Sounds.instance.Death(); } catch { }
        ballObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ballObject.transform.position = new Vector3(3.71f, 3.29f, -4.80f);
    }

    private void UpdateUI() {
        scoreText.text = "Score: "+score.ToString();
        bestText.text = "Best: "+best.ToString();
        ballText.text = "Ball: "+ball.ToString() + "/3";
    }

    private void ShowGameOverUI(bool x) {
        scoreText.enabled = !x;
        bestText.enabled = !x;
        ballText.enabled = !x;

        gameOver.enabled = x;
        best2Text.enabled = x;
        retryButton.SetActive(x);
        menuButton.SetActive(x);
        best2Text.text = "Best: " + best.ToString();

    }


}
