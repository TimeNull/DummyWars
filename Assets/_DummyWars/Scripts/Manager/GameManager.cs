using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : SceneSingleton<GameManager>
{
    public string singletonCheck;

    [HideInInspector]
    public NPCManager NPCManager;

    private void Awake()
    {
        NPCManager = GetComponent<NPCManager>();
        Debug.Log("A palavra-chave da cena atual é: " + Instance.singletonCheck);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
