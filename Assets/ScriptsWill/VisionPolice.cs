using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AI;

public class VisionPolice : MonoBehaviour
{
    /// <summary>
    /// Script de la vision de la police.
    /// Celle-ci a pour but d'immiter la vision d'un être humain si s'apparente à une partie de sphère
    /// Pour ce faire, j'ai décidé d'utiliser les coordonnées sphériques 
    /// </summary>

    [SerializeField]
    public GameObject banditos;         //utile au policier afin de lui faire regarder le joueur
    private Vector3 positionBandit;
    private Transform positionPolice;

    private float rayon;    //La distance radiale, équivalent de Rhô, dans les coordonnés sphériques
    float minMaxAngleXZ ;   //Équivalent de thêta, dans les coordonnés sphériques
    float minMaxAngleYZ;    //Équivalent de Phi, dans les coordonnés sphériques

    bool rayonBool = false;
    bool angleXZBool = false;
    bool angleYZBool = false;
    bool thereIsNoWalls = false;

    public bool topVision;      //Varianle la plus importante du scipt. Elle est vrai si le 
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
        if (KeepOverTimeComponent.difficulty == 2)
        {
            minMaxAngleXZ = 40;
            minMaxAngleYZ = 10;
            rayon = 15;
        }
        else
        {
            minMaxAngleXZ = 45;
            minMaxAngleYZ = 15;
            rayon = 20;
        }

    }

    void Update()
    {
        positionBandit = GameObject.Find("Bandit").transform.position;
        positionPolice = GetComponentInParent<Transform>();
         
        //On regarde 1 à 1 les conditions à respecter afin de voir le joueur
        CheckRayon();
        CheckAngleXZ();
        CheckAngleYZ();
        CheckWalls();

        //Si les conditions sont respecté, cette fonction s'occupera du reste
        ChekAll();

    }

    private void CheckRayon()
    {
        //LES 5 PROCHAINE LIGNES SERVENT À DÉTERMINER SI LE JOUEUR EST DANS LE RAYON PRÉDÉFINI DU POLICIER DU POLICIER
        var distanceRayon = Vector3.Distance(positionPolice.position, positionBandit);

        rayonBool = false;
        if (distanceRayon <= rayon)
        {
            rayonBool = true;
        }
    }
  
    /// <summary>
    /// Vérification la plus lourde : celle de thêta
    /// En effet, celle-ci doit tenir compte de la rotation de la police. 
    /// Aussi, en raison de la facon dont unity illustre ses composantes d'angle, de nombreuses manipulation sont nécéssaire
    /// </summary>
    private void CheckAngleXZ()
    {
        
        var xPolice = positionPolice.position.x;     
        var zPolice = positionPolice.position.z;     

        var d1 = positionBandit.z - zPolice;
        var d2 = positionBandit.x - xPolice;

        //Les prochaines manipulations ont pour but de changer les angles de facon à ce qu'elles soit bien comparable. 
        //Les angles dans unity ne font pas l'affaire. Une fois les manipulations terminés, il sera BEAUCOUP plus 
        //  simple d'éffectuer les comparaisons requise 

        var teta1 = Mathf.Atan(d1 / d2);
        var tetaDeg = teta1 * Mathf.Rad2Deg;
        var tetaDeg2 = RightConversion(tetaDeg,d1,d2);      //fonction facilitant la conversion   
        var rotPolice = Mathf.Abs(positionPolice.eulerAngles.y);
        var rotPolice2 = RightConversion2(rotPolice);       //fonction facilitant la conversion

        var test = tetaDeg2;

        var UpAngle = rotPolice2  + minMaxAngleXZ;
        var DownAngle = rotPolice2 - minMaxAngleXZ;

        if(UpAngle > 360)      
            UpAngle -= 360;        

        if (DownAngle < 0)    
            DownAngle += 360;
        
        //Les prochaines lignes s'occuppent de la vérifiation, si oui ou non l'angle Thêta entre joueur et policier est respecté

        angleXZBool = false;

        if ((UpAngle < (2*minMaxAngleXZ) && DownAngle > 360 - (2 * minMaxAngleXZ)) && (test < UpAngle || test > DownAngle))
            angleXZBool = true;
              
        else if (test < UpAngle && test > DownAngle) 
            angleXZBool = true;
             
    }

    /// <summary>
    /// Similaire à la fonction précédente, celle permet une vérification d'un angle Phi : l'angle asocié à la hauteur
    /// </summary>
    private void CheckAngleYZ()
    {
        var yPolice = positionPolice.position.y;     
        var zPolice = positionPolice.position.z;     
        var xPolice = positionPolice.position.x;

        var l1 =   Mathf.Sqrt (    Mathf.Pow(positionBandit.z - zPolice,2) + Mathf.Pow(positionBandit.x - xPolice, 2));
        var l2 = Mathf.Abs(positionBandit.y - yPolice);
    
        var tetaUp = Mathf.Atan(l2 / l1);

        var tetaDegUp = tetaUp * Mathf.Rad2Deg;

        angleYZBool = false;
        if (tetaDegUp < minMaxAngleYZ)
        {
            angleYZBool = true;
        }
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

        rotPolice -= 90;
        rotPolice = rotPolice * -1;
        rotPolice += 360;

        if (rotPolice >= 360)     
            rotPolice -= 360;

        return rotPolice;
    }

    /// <summary>
    /// Vérifie chacune des conditions
    /// </summary>
    public void ChekAll()
    {
        // Débugage
        //if (gameObject.name == "police1Jean") 
        //{
        //    print("rayon :" + rayonBool);
        //    print("angledg :" + angleXZBool);
        //    print("anglehauteur :" + angleYZBool);
        //    print("walls :" + thereIsNoWalls);
        //}

        if (rayonBool && angleXZBool && angleYZBool && thereIsNoWalls)
        {
            topVision = true;
            transform.LookAt(banditos.transform);       //Fonction permettant d'de rotater un gameobject vers un autre
        }
        else      
            topVision = false;
        
    }


    /// <summary>
    /// Fonction s'occupant d'observer s'il y a présence de mur entre le joueur et le policier
    /// </summary>
    public void CheckWalls()
    {
        thereIsNoWalls = false;
        if (!Physics.Linecast(transform.position, positionBandit, LayerMask.GetMask("WallsAI")))    
            thereIsNoWalls = true;
        
    }
}

