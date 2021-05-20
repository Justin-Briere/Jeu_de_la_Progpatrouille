using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyScaleComponent : MonoBehaviour    // Script inspiré de la session passée modifiant la grosseur du texte.
{
    Vector3 Bigger = new Vector3(1.5f, 1.5f, 1.5f);

    public void AgrandirBouton()
    {
        transform.localScale = Bigger;
    }

    public void RétrécirBouton()
    {
        transform.localScale = Vector3.one;
    }
}

