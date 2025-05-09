using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public CharacterSelectionManager.Character[] characterPrefabs;
    public Transform spawnPoint;
    
    void Start()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        
        // Make sure the index is valid
        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characterPrefabs.Length)
        {
            GameObject playerCharacter = Instantiate(
                characterPrefabs[selectedCharacterIndex].playerPrefab,
                spawnPoint.position,
                Quaternion.identity
            );
            
            // You might need to set up references or assign components here
            // For example, finding the camera and making it follow the player
            Camera.main.GetComponent<CameraFollow>()?.SetTarget(playerCharacter.transform);
        }
        else
        {
            Debug.LogError("Invalid character index!");
        }
        
        // Start the battle music
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayBattleMusic();
        }
    }
}
