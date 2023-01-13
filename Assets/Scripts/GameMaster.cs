using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance = null;

    public GameObject playerCharacter;
    public int selectedIndex = 0;

    // Start is called before the first frame update
    private void Awake()
    {

        if (Instance == null)
        {
            try
            {
                Debug.Log(Instance.ToString());
            }
            catch { }
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log(Instance.ToString());
            Destroy(gameObject);
        }

        Screen.SetResolution(1920, 1080, true);

    }
    
    public void DanceChange(int danceIndex) {
        playerCharacter.GetComponent<Animator>().SetInteger("dance", danceIndex);
        selectedIndex = danceIndex;
    }

    public void LaunchGameScene(int index) {
        SceneManager.LoadScene(index);
    }

}
