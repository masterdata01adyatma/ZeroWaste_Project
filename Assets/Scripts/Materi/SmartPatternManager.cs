using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmartPatternManager : MonoBehaviour
{
    public void OpenTeori()
    {
        PlayerPrefs.SetInt("MateriTerpilih", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MateriDetail");
    }

    public void OpenBlouse()
    {
        PlayerPrefs.SetInt("MateriTerpilih", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MateriDetail");
    }

    public void OpenDress()
    {
        PlayerPrefs.SetInt("MateriTerpilih", 2);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MateriDetail");
    }

    public void OpenRok()
    {
        PlayerPrefs.SetInt("MateriTerpilih", 3);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MateriDetail");
    }
}
