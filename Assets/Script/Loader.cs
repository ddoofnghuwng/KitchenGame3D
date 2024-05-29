using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        MenuScene,
        GameScene,
        LoadingScene
    }

    public static int tagetSceneIndex;

    private static Scene tagetScene;

    public static void Load(Scene tagetScene)
    {
        Loader.tagetScene = tagetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallBack()
    {
        SceneManager.LoadScene(tagetScene.ToString());
    }
}
