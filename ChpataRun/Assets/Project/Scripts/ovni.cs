using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ovni : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickRestart()
    {
        SceneManager.LoadScene("level3", LoadSceneMode.Single);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
