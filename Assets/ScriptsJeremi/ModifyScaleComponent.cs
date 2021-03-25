using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyScaleComponent : MonoBehaviour    // Script inspiré de la session passée
{
    Vector3 Grandeur = new Vector3(1, 1, 1);

    public void AgrandirBouton()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void RétrécirBouton()
    {
        transform.localScale = Vector3.one;
    }
}

