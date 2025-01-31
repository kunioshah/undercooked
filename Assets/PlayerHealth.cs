using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        hp = 10;
        Debug.Log("full health! 10/10");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //damage testing
        {
            hp = hp - 1; 
            Debug.Log(hp+"/10 hp");
        }
        if(hp<=0 || hp == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
