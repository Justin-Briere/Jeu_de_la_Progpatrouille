using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour
{
   public bool EasyDifficulty;
    public bool MediumDifficulty;
    public bool HardDifficulty = true;
    public void EazyMode()
    {
        EasyDifficulty = true;
        MediumDifficulty = false;
        HardDifficulty = false;
    }
    public void MediumMode()
    {
        EasyDifficulty = false;
        MediumDifficulty = true;
        HardDifficulty = false;
    }
    public void HardMode()
    {
        EasyDifficulty = false;
        MediumDifficulty = false;
        HardDifficulty = true;
    }

}
    