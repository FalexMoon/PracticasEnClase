using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneIdex;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneIdex);
    }

}
