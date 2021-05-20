using UnityEngine;

public class RotationPrimitive : MonoBehaviour  //Script de la dernière session pour le Galaga gérant la rotation.
{
   [SerializeField]
   Vector3 VecteurRotation;

   bool RotationActivée { get; set; } = false;

   void Awake()
   {
      RotationActivée = true;
   }

   public void CommuterActivationRotation()
   {
      RotationActivée = !RotationActivée;
   }

   void Update()
   {
      if (RotationActivée)
      {
         transform.Rotate(VecteurRotation * Time.deltaTime);
      }
   }
}
