using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomButton : MonoBehaviour
{
    public ClickButton[] buttons;
    public List<int> Colors;

    float viewTime = 1f;

    float pauseTime = 100000000000f;
    public int level;
    private int currentlvl;

    bool generator = false;
    public bool player = false;

    public Button StartButton;
    public Text gameOverText;
    public Text scoreTexte;
    int score;
    private int myRandom;

    int EASY_SCORE = 10;
    int MEDIUM_SCORE = 15;
    int HARD_SCORE = 21;

    public bool gameCompleted = false;

    void Start()
    {
        for (int i = 0; i < buttons.Length; ++i)
        {
            buttons[i].onClick += ButtonPressed;
            buttons[i].number = i;
        }
    }

    void ButtonPressed(int number)
    {
        if(player)
        {
            if(number == Colors[currentlvl])
            {
                currentlvl++;
                score++;
                scoreTexte.text = score.ToString();
            }
            else
            {
                EndGame();
            }
            if(currentlvl == level)
            {
                level++;
                currentlvl = 0;
                player = false;
                generator = true;
            }
        }
    }
    void Update()
    {
        GameCompleted();
        if (generator)
        {
            generator = false;
            StartCoroutine(RandomButtons());
        }
    }
    private IEnumerator RandomButtons()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < level; i++)
        {
            if(Colors.Count < level)
            {
                myRandom = Random.Range(0, buttons.Length);
                Colors.Add(myRandom);
            }
            buttons[Colors[i]].SelectedColor();
            yield return new WaitForSeconds(viewTime);
            buttons[Colors[i]].UnSelectedColor();
            yield return new WaitForSeconds(pauseTime);
        }
        player = true;
    }
    public void StartGame()
    {
        Colors.Clear();
        generator = true;
        score = 0;
        currentlvl = 0;
        level = 1;
        gameOverText.text = "";
        scoreTexte.text = score.ToString();
        StartButton.interactable = false;
    }
    void EndGame()
    {
        gameOverText.text = "Game Over";
        StartButton.interactable = true;
        player = false;
    }
    public void GameCompleted()
    {
        if (score == EASY_SCORE)
        {
            gameOverText.text = "Congratulations!!!";
            StartButton.interactable = true;
            player = false;
            generator = false;
            KeepOverTimeComponent.JeuRéussi = true;
            //gameCompleted = true;
            //SceneManager.LoadScene("FinalScene");
        }
    }
    //public bool GameCompleted()
    //{
    //    bool gameCompleted = false;
    //    if (score == EASY_SCORE)
    //    {
    //        gameOverText.text = "Congratulations!!!";
    //        StartButton.interactable = true;
    //        player = false;
    //        generator = false;
    //        SceneManager.LoadScene("FinalScene");
    //        gameCompleted = true;
    //    }
    //    return gameCompleted;
    //}
}
