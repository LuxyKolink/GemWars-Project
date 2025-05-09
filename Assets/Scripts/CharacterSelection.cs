using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    [System.Serializable]
    public class Character
    {
        public string name;
        public Sprite portrait;
        public GameObject playerPrefab;
    }
    
    public List<Character> availableCharacters = new List<Character>();
    public Transform characterDisplayPosition;
    
    private int currentCharacterIndex = 0;
    private GameObject currentCharacterPreview;
    
    public UnityEngine.UI.Text characterNameText;
    public UnityEngine.UI.Image characterPortrait;
    
    void Start()
    {
        // Start with the first character selected
        if (availableCharacters.Count > 0)
        {
            ShowCharacter(0);
        }
        
        // Play menu music if there's an AudioManager
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayBattleMusic();
        }
    }
    
    void ShowCharacter(int index)
    {
        if (availableCharacters.Count == 0) return;
        
        // Update current index
        currentCharacterIndex = index;
        
        // Update UI elements
        Character character = availableCharacters[currentCharacterIndex];
        characterNameText.text = character.name;
        characterPortrait.sprite = character.portrait;
        
        // Update character preview
        if (currentCharacterPreview != null)
        {
            Destroy(currentCharacterPreview);
        }
        
        if (character.playerPrefab != null && characterDisplayPosition != null)
        {
            currentCharacterPreview = Instantiate(character.playerPrefab, 
                                               characterDisplayPosition.position,
                                               Quaternion.identity);
        }
    }
    
    public void NextCharacter()
    {
        int nextIndex = (currentCharacterIndex + 1) % availableCharacters.Count;
        ShowCharacter(nextIndex);
    }
    
    public void PreviousCharacter()
    {
        int prevIndex = (currentCharacterIndex - 1 + availableCharacters.Count) % availableCharacters.Count;
        ShowCharacter(prevIndex);
    }
    
    public void SelectCharacter()
    {
        // Save the selected character ID in PlayerPrefs
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
        PlayerPrefs.Save();
        
        // Load the game scene
        SceneManagement.LoadScene("SampleScene"); // Change to your game scene name
    }
    
    public void BackToMainMenu()
    {
        SceneManagement.LoadScene("MainMenu"); // Change to your main menu scene name
    }
}
