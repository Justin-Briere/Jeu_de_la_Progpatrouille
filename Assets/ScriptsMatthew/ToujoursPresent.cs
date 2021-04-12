using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToujoursPresent : MonoBehaviour
{
    private static bool IsCreated;

    static ToujoursPresent()
    {
        IsCreated = false;
    }
    // Start is called before the first frame update
    void Awake()
    {
        if(!IsCreated)
        {
            DontDestroyOnLoad(this.gameObject);
            IsCreated = true;
        }
    }
}
