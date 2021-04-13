using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomButton : MonoBehaviour
{
    public ClickButton[] buttons;
    public List<int> ColorList;

    public float viewTime = 0.5f;

    public float pauseTime = 0.5f;
    public int level = 2;
    private int currentlvl;

    bool generator = false;
    public bool player = false;

    public Button StartButton;
    public Text gameOverText;
    public Text scoreTexte;
    int score;
    private int myRandom;

    // Start is called before the first frame update
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
            if(number == ColorList[currentlvl])
            {
                currentlvl++;
                score++;
                scoreTexte.text = score.ToString();
            }
            else
            {
                GameOver();
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
    // Update is called once per frame
    void Update()
    {
        if (generator)
        {
            generator = false;
            StartCoroutine(Robot());
        }
    }

    private IEnumerator Robot()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < level; i++)
        {
            if(ColorList.Count < level)
            {
                myRandom = Random.Range(0, buttons.Length);
                ColorList.Add(myRandom);
            }
            buttons[ColorList[i]].SelectedColor();
            yield return new WaitForSeconds(viewTime);
            buttons[ColorList[i]].UnSelectedColor();
            yield return new WaitForSeconds(pauseTime);
        }
        player = true;
    }
    public void StartGame()
    {
        ColorList.Clear();
        generator = true;
        score = 0;
        currentlvl = 0;
        level = 2;
        gameOverText.text = "";
        scoreTexte.text = score.ToString();
        StartButton.interactable = false;
    }
    void GameOver()
    {
        gameOverText.text = "Game Over";
        StartButton.interactable = true;
        player = false;

    }
}
