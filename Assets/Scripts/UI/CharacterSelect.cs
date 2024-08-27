using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject [] skins;

    public int selectedCharacter;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);

        foreach (GameObject player in skins)
        {
            player.SetActive(false);
        }

        skins[selectedCharacter].SetActive(true);
    }
    public void ChangeNext()
    {
       
        skins[selectedCharacter].SetActive(false);

        selectedCharacter =(++selectedCharacter)% (skins.Length );
        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }
    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;

        if (selectedCharacter < 0)
        {
            selectedCharacter = skins.Length-1;
        }
        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
