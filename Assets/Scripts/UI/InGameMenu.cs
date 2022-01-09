using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    string m_Scene;
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
