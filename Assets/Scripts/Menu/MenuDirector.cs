using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuDirector : MonoBehaviour
{

    public GameObject[] itens;
    private string NextScene;
    private bool GoToNextScene = false;

    private float timerToFade = 1f;
    private CanvasScaler canvas;

    void Start()
    {
        canvas = GetComponent<CanvasScaler>();

    }

    void Update()
    {

        if (GoToNextScene)
        {
            timerToFade -= Time.deltaTime;
            if (timerToFade <= 0) {

                StartGame();

            }

            FreezeMenu();

        }

    }

    public void GoToScene(string scene)
    {
        NextScene = scene;
        GoToNextScene = true;
    }

    #region START_GAME
    private const string START_GAME = "7_TrainingField";
    public GameObject SceneLoaderMenu;
    private bool alreadyFade = false;
    private float timerToTransition = 1.4f;

    private void StartGame()
    {

        if (NextScene.Equals(START_GAME) && !alreadyFade)
        {
            var sceneLoaderMenu = Instantiate(SceneLoaderMenu, new Vector3(canvas.referenceResolution.x / 2, canvas.referenceResolution.y / 2, 0), Quaternion.identity);
            sceneLoaderMenu.transform.SetParent(transform);
            alreadyFade = true;
        }

        if (alreadyFade)
        {
            timerToTransition -= Time.deltaTime;
            if (timerToTransition <= 0)
            {
                SceneManager.LoadScene(NextScene);
            }
        }


    }

    #endregion

    private void FreezeMenu()
    {
        foreach (GameObject item in itens)
        {
            item.GetComponent<Button>().interactable = false;
            item.SendMessage("Stop", true);
        }
    }

}
