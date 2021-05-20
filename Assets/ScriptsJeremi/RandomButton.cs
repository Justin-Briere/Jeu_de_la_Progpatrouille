using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomButton : MonoBehaviour //Script inspiré de Yasil : https://www.youtube.com/watch?v=OmynDREHO_8
{
    public ClickButton[] buttons;
    public List<int> Colors;

    float deltaTime = 0.5f;
    float MEDIUM_DELTA_TIME = 0.25f;
    float HARD_DELTA_TIME = 0.1f;


    public int level;
    private int currentlvl;

    bool generator = false;
    public bool player = false;

    public Button StartButton;
    public Text gameOverText;
    public Text scoreTexte;
    int score;
    private int myRandom;

    int MEDIUM_SCORE = 15;
    int HARD_SCORE = 21;
    int completedScore = 10;

    public void AdjustDifficulty() //Fonction servant à ajuster des paramètres selon la difficulté choisie.
    {
        if (KeepOverTimeComponent.difficulty == 2)
        {
            completedScore = MEDIUM_SCORE;
            deltaTime = MEDIUM_DELTA_TIME;

        }
        if (KeepOverTimeComponent.difficulty == 3)
        {
            completedScore = HARD_SCORE;
            deltaTime = HARD_DELTA_TIME;
        }
    }

    public bool gameCompleted = false;

    void Start()
    {
        AdjustDifficulty();
        for (int i = 0; i < buttons.Length; ++i)
        {
            buttons[i].OnClick += ButtonPressed;
            buttons[i].numberPosition = i;
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
            yield return new WaitForSeconds(deltaTime);
            buttons[Colors[i]].UnSelectedColor();
            yield return new WaitForSeconds(deltaTime);
        }
        player = true;
    }
    public void StartGame() //Fonction lorsque le bouton Start est appuyé
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
    void EndGame() //Fonction qui s'occupe du joueur qui échoue. 
    {
        gameOverText.text = "Game Over";
        StartButton.interactable = true;
        player = false;
    }
    public void GameCompleted() //Fonction qui gère ce qui se produit lorsque le jeu est réussi.
    {
        if (score == completedScore)
        {
            gameOverText.text = "Congratulations!!!";
            StartButton.interactable = true;
            player = false;
            generator = false;
            KeepOverTimeComponent.SimonRéussi = true;
            SceneManager.LoadScene("FinalScene");
        }
    }
}
