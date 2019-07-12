using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManage : MonoBehaviour
{
    static string NextSceneName;
    public int test=0;
    float startTime;

    
    AsyncOperation asyncOperation;
    // Start is called before the first frame update
    void Start()
    {
       
        if (SceneManager.GetActiveScene().name == "loading")
        {
            startTime = Time.time;
            asyncOperation = SceneManager.LoadSceneAsync(NextSceneName);
            asyncOperation.allowSceneActivation = false;
            test = 1;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (asyncOperation != null)
        {
            if (Time.time - startTime > 5 )
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
    public void LoadLoadingScene(string NextScene)
    {
        SceneManager.LoadSceneAsync("loading");
        NextSceneName = NextScene;
    }

}
