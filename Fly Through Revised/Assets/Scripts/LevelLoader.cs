using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void LoadNextLevel(int levelIdx)
    {
        StartCoroutine(LoadLevel(levelIdx));
    }

    IEnumerator LoadLevel(int levelIdx)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIdx);


        if (levelIdx != 0)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.Game);
        }
    }
}
