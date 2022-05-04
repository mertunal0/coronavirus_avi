using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oyun : MonoBehaviour
{
    public void Reklam_Oynat()
    {

    }

    public void Sahneyi_Bastan_Baslat()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Time.timeScale = 1.0f;
    }
}
