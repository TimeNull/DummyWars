using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void GameChange();

public class GameManager : SceneSingleton<GameManager>
{
    [SerializeField] GameObject gameOverCanvas, victoryCanvas;

    public string singletonCheck;

    public GameChange startGame;
    public GameChange restartGame;
    public GameChange gameOver;
    public GameChange victory;

    [HideInInspector]
    public NPCManager NPCManager;

    private bool gamePaused = false;

    private void Awake()
    {
        DynamicGI.UpdateEnvironment();
        NPCManager = GetComponent<NPCManager>();
        Debug.Log("A palavra-chave da cena atual é: " + Instance.singletonCheck);
    }

    private void OnEnable()
    {
        gameOver += GameOver;
        victory += Victory;
    }

    private void OnDisable()
    {
        gameOver -= GameOver;
        victory -= Victory;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("START GAME");
            startGame.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !gamePaused)
        {
            //TODO: pause Game
            gamePaused = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && gamePaused)
        {
            //TODO: unpause Game
            gamePaused = false;
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            //TODO: restart Game
        }

    }

    public void StartGame()
    {
        startGame.Invoke();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }

    public void Victory()
    {
        Time.timeScale = 0;
        victoryCanvas.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnableObject (GameObject targetObject)
    {
        targetObject.SetActive(true);
    }

    public void DisableObject (GameObject targetObject)
    {
        targetObject.SetActive(false);
    }

    public void PauseGameButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void UnpauseGameButton()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
    }

    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void SpawnThisObject(GameObject targetObject)
    {
        SummonManager.spawnObject = targetObject;
    }
}
