using UnityEngine;

public class RotationPrimitive : MonoBehaviour
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
