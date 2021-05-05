using UnityEngine;

public class FinalScreenManager : MonoBehaviour
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
