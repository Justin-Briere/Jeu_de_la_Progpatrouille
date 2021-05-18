using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AI;

public class VisionPolice : MonoBehaviour
{
    /// <summary>
    /// Script de la vision de la police.
    /// Celle-ci a pour but d'immiter la vision d'un être humain qui s'apparente à une partie de sphère
    /// Pour ce faire, j'ai décidé d'utiliser les coordonnées sphériques 
    /// </summary>

    [SerializeField]
    public GameObject banditos;         //utile au policier afin de lui faire regarder le joueur
    private Vector3 positionBandit;
    private Transform positionPolice;

    private float rayon;    //La distance radiale, équivalent de Rhô, dans les coordonnés sphériques
    float minMaxAngleXZ ;   //Équivalent de thêta, dans les coordonnés sphériques
    float minMaxAngleYZ;    //Équivalent de Phi, dans les coordonnés sphériques

    public bool vueSurBandit;      //Variable la plus importante du scipt. Elle est vrai si le 
                                   //policier regarde le joueur et fausse dans le cas contraire

    void Start()
    {

        //Permet d'ajuster le niveau de difficulté choisit au jeu
        if (KeepOverTimeComponent.difficulty == 1)
        {
            minMaxAngleXZ = 35;
            minMaxAngleYZ = 5;
            rayon = 10;

        }
        else if (KeepOverTimeComponent.difficulty == 2)
        {
            minMaxAngleXZ = 40;
            minMaxAngleYZ = 15;
            rayon = 20;
        }
        else
        {
            minMaxAngleXZ = 45;
            minMaxAngleYZ = 20;
            rayon = 20;
        }

    }

    void Update()
    {
        positionBandit = GameObject.Find("Bandit").transform.position;
        positionPolice = GetComponentInParent<Transform>();

        // Pour des raisons de performances : on appelle seulement ChekRayon(), qui appellera le prochain si nécéssaire et ainsi de suite.
        // vueSurBandit, false au début, devient true si on respecte les 3 autres conditions : CheckAngleXZ(), CheckAngleYZ() et CheckWalls();
       
        vueSurBandit = false;
        CheckRayon();

        //Si les conditions sont respectés, cette fonction de regarder le joueur
        if (vueSurBandit)
            transform.LookAt(banditos.transform);       //Fonction unity permettant de rotater un gameobject vers un autre

    }

    private void CheckRayon()
    {
        //LES 2 PROCHAINE LIGNES SERVENT À DÉTERMINER SI LE JOUEUR EST DANS LE RAYON PRÉDÉFINI DU POLICIER DU POLICIER

        var distanceRayon = Vector3.Distance(positionPolice.position, positionBandit);

        if(distanceRayon <= rayon)
            CheckAngleXZ();    

    }
  
    /// <summary>
    /// Vérification la plus lourde : celle de thêta
    /// En effet, celle-ci doit tenir compte de la rotation de la police. 
    /// Aussi, en raison de la facon dont unity illustre ses composantes d'angle, de nombreuses manipulation sont nécéssaire
    /// </summary>
    private void CheckAngleXZ()
    {
        var deltaZ = positionBandit.z - positionPolice.position.z;
        var deltaX = positionBandit.x - positionPolice.position.x;

        //Les prochaines manipulations ont pour but de changer les angles de facon à ce qu'elles soit bien comparable. 
        //Les angles dans unity ne font pas l'affaire. Une fois les manipulations terminés, il sera BEAUCOUP plus 
        //  simple d'éffectuer les comparaisons requise 

        var teta = Mathf.Atan(deltaZ / deltaX);
        var tetaDeg = teta * Mathf.Rad2Deg;
        var tetaDegConversion = RightConversion(tetaDeg,deltaZ,deltaX);      //fonction facilitant la conversion   
        var rotPolice = Mathf.Abs(positionPolice.eulerAngles.y);
        var rotPoliceConversion = RightConversion2(rotPolice);       //fonction facilitant la conversion

        var UpAngle = rotPoliceConversion  + minMaxAngleXZ;          //les 2 lignes suivantes forme lees extrémités du champ de vision
        var DownAngle = rotPoliceConversion - minMaxAngleXZ;

        if(UpAngle > 360)      
            UpAngle -= 360;        

        if (DownAngle < 0)    
            DownAngle += 360;

        //Les prochaines lignes s'occuppent de la vérifiation, si oui ou non l'angle Thêta entre joueur et policier est respecté

        if ((UpAngle < (2 * minMaxAngleXZ) && DownAngle > 360 - (2 * minMaxAngleXZ)) && (tetaDegConversion < UpAngle || tetaDegConversion > DownAngle) || (tetaDegConversion < UpAngle && tetaDegConversion > DownAngle))      
            CheckAngleYZ();
        
        
    }

    /// <summary>
    /// Similaire à la fonction précédente, celle permet une vérification d'un angle Phi : l'angle asocié à la hauteur
    /// </summary>
    private void CheckAngleYZ()
    {
        var deltaXZ =   Mathf.Sqrt (    Mathf.Pow(positionBandit.z - positionPolice.position.z,2) + Mathf.Pow(positionBandit.x - positionPolice.position.x, 2));
        var deltaY = Mathf.Abs(positionBandit.y - positionPolice.position.y);
    
        var tetaUp = Mathf.Atan(deltaY / deltaXZ);

        var tetaDegUp = tetaUp * Mathf.Rad2Deg;

        if (tetaDegUp < minMaxAngleYZ)
            CheckWalls();
    }

    /// <summary>
    /// Fonction utile à la vérification de l'angle thêta ,afin de ne pas trop alourdir la fonction CheckAngleXZ
    /// </summary>
    /// <param name="tetaDeg"></param>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public float RightConversion(float tetaDeg,float d1,float d2)
    {
        if (d2 < 0)      
            tetaDeg += 180;
        
        else if (d1 < 0)        
            tetaDeg += 360;

        return tetaDeg;
    }

    /// <summary>
    /// Fonction utile à la vérification de l'angle thêta ,afin de ne pas trop alourdir la fonction CheckAngleXZ
    /// </summary>
    /// <param name="rotPolice"></param>
    /// <returns></returns>
    public float RightConversion2(float rotPolice)
    {
         rotPolice = -rotPolice + 450;

        if (rotPolice >= 360)     
            rotPolice -= 360;

        return rotPolice;
    }


    /// <summary>
    /// Fonction s'occupant d'observer s'il y a présence de mur entre le joueur et le policier
    /// </summary>
    public void CheckWalls()
    {
        if (!Physics.Linecast(transform.position, positionBandit, LayerMask.GetMask("WallsAI")))
            vueSurBandit = true;         //toutes les conditions sont respectés
           
    }
}

