using Assets.Scenes.script.Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllor : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(Consts.Scene.InitialScene);
    }

    public void MoveToPond()
    {
        SceneManager.LoadScene(Consts.Scene.Pond);
    }

    public void MoveToBotanicalGarden()
    {
        SceneManager.LoadScene(Consts.Scene.BotanicalGarden);
    }

    public void MoveToPrivateSchool()
    {
        SceneManager.LoadScene(Consts.Scene.PrivateSchool);
    }

    public void MoveToMainScene()
    {
        SceneManager.LoadScene(Consts.Scene.MainScene);
    }
}
