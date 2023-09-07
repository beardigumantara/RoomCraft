using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Homepage : MonoBehaviour
{
   public void StartGame()
   {
    SceneManager.LoadScene("SampleScene");
   }
   public void LinkDocumentation()
   {
      Application.OpenURL("https://developers.google.com/ar/devices?hl=id");
   }
   public void TokoKursi()
   {
      Application.OpenURL("https://shp.ee/8k4wzbn");
   }
   public void TokoMeja()
   {
      Application.OpenURL("https://shp.ee/7c3e29b");
   }
   public void TokoMejaNakas()
   {
      Application.OpenURL("https://shp.ee/m8if3gq");
   }
   public void TokoLemari()
   {
      Application.OpenURL("https://shp.ee/ejgczfj");
   }
   public void TokoKasur()
   {
      Application.OpenURL("https://shp.ee/sqbftek");
   }
   public void QuitGame()
   {
    Debug.Log("Quit");
    Application.Quit();
   }
}
