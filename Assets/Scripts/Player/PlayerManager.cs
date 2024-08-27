using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.Audio;

public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    public GameObject gameOverScreen;

    public static Vector2 lastCheckpointsPos=new Vector2(-8,1);//Position initiale depuis la scene

    public static int numberOfCoins = 0;

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI stageText;
    public GameObject[] playerPrefabs;

    public CinemachineVirtualCamera virtualCamera;

    public GameObject pauseMenuScreen;

    private int currentSceneIndex=0;


    private void Awake()
    {
        int charcterIndex= PlayerPrefs.GetInt("SelectedCharacter", 0);
        
        GameObject selected_player= Instantiate(playerPrefabs[charcterIndex], lastCheckpointsPos,Quaternion.identity);

        virtualCamera.m_Follow = selected_player.transform;

        //numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins",0);
        isGameOver = false;


        

    }
    // Start is called before the first frame update
    void Start()
    {
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex ;

        stageText.text = "Stage " + (currentSceneIndex.ToString());


        Scene scene = SceneManager.GetActiveScene();

        AudioManager.instance.Play("BackGroundSound");
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            gameObject.SetActive(false);
            return;
        }
        else
        {




            if (Input.GetKeyDown(KeyCode.Escape) )
            {
                if (Time.timeScale == 1)
                PauseGame();
                else
                    ResumeGame();
                
            }


           



        }

        coinsText.text=(numberOfCoins.ToString());

        

    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        //AudioManager.instance.Play("BackGroundSound");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
        //AudioManager.instance.Play("BackGroundSound");
    } 
    
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);

    }
    public static void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
