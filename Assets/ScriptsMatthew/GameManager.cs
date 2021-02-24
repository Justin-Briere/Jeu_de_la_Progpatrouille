using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Aide à l'aide d'un site pour le static GameManager Instance
    public static GameManager Instance;

    public Transform lastCheckPoint;
    void Awake()
    {
        Instance = this;
    }
}
