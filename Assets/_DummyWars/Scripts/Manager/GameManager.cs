using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void GameChange();

public class GameManager : SceneSingleton<GameManager>
{
    public string singletonCheck;

    public GameChange startGame;
    public GameChange pauseGame;
    public GameChange restartGame;

    [HideInInspector]
    public NPCManager NPCManager;

    private bool gamePaused;

    private void Awake()
    {
        DynamicGI.UpdateEnvironment();
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

        if (Input.GetKeyDown(KeyCode.Space) && gamePaused)
        {
            startGame.Invoke();
            gamePaused = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !gamePaused)
        {
            pauseGame.Invoke();
            gamePaused = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            startGame.Invoke();
        }

    }
}
