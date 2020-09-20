using Assets.Scenes.script.Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void TurnScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
