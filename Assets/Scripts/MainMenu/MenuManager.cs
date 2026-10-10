using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void MenuMateri()
    {
        SceneManager.LoadScene("SmartPattern");
    }
    public void MenuSimulasi()
    {
        SceneManager.LoadScene("AnalisisBahan");
    }
    public void MenuKuis()
    {
        SceneManager.LoadScene("Quiz");
    }
    public void MenuEvaluasi()
    {
        SceneManager.LoadScene("Evaluasi");
    }
    public void MenuPanduan()
    {
        SceneManager.LoadScene("MenuPanduan");
    }
    public void MenuVideo()
    {
        SceneManager.LoadScene("MenuVideo");
    }
    public void MenuTentang()
    {
        SceneManager.LoadScene("Tentang");
    }
}
