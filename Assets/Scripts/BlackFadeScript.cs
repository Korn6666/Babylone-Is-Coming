using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BlackFadeScript : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadParking());
    }
    private IEnumerator LoadParking()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
