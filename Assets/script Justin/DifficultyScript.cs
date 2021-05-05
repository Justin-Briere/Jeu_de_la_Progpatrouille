using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour
{
   public bool EasyDifficulty;
    public bool MediumDifficulty;
    public bool HardDifficulty;
    
    private void OnCollisionEnter(Collision other)
    {
       // print(other.gameObject.name);
        if ((other.gameObject.name == "EzWall"))EazyMode();
        if ((other.gameObject.name == "MedWall")) MediumMode();
        if ((other.gameObject.name == "HardWall")) HardMode();
    }
    public void EazyMode()
    {
        print("ez");
            EasyDifficulty = true;
        MediumDifficulty = false;
        HardDifficulty = false;
    }
    public void MediumMode()
    {
        print("med");
        EasyDifficulty = false;
        MediumDifficulty = true;
        HardDifficulty = false;
    }
    public void HardMode()
    {
        print("hard");
        EasyDifficulty = false;
        MediumDifficulty = false;
        HardDifficulty = true;
    }

}
    