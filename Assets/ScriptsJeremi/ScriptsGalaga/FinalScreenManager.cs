using UnityEngine;

public class FinalScreenManager : MonoBehaviour  //// Script de la dernière session gérant le massage de la scène final de Galaga.
{
   private void Start()
   {
      GetComponentInChildren<TextMesh>().text = GameObject.Find("GlobalGameManager").GetComponent<GameMasterFSM>().MessageFinal;
   }
   public void Redémarrer()
   {
      GameObject.Find("GlobalGameManager").GetComponent<GameMasterFSM>().ProchaineScène();
   }
}
