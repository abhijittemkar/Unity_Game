using UnityEngine;
using TMPro;

public class PlayerSelection : MonoBehaviour
{
    public GameObject robotPlayer;
    public GameObject clownPlayer;
    public GameObject nerdPlayer;
    public GameObject soldierPlayer;
    public GameObject grannyPlayer;

    void Start()
    {
        // Load the saved selected button when the game starts
        string savedButtonName = PlayerPrefs.GetString("SelectedButton", "");

        // Select the player based on the saved button or default to "SelRobot"
        switch (savedButtonName)
        {
            case "SelClown":
                SelectPlayer(clownPlayer);
                break;
            case "SelNerd":
                SelectPlayer(nerdPlayer);
                break;
            case "SelSoldier":
                SelectPlayer(soldierPlayer);
                break;
            case "SelGranny":
                SelectPlayer(grannyPlayer);
                break;
            case "SelRobot":
            default:
                SelectPlayer(robotPlayer);
                break;
        }
    }

    void SelectPlayer(GameObject player)
    {
        // Activate the selected player and deactivate others
        robotPlayer.SetActive(player == robotPlayer);
        clownPlayer.SetActive(player == clownPlayer);
        nerdPlayer.SetActive(player == nerdPlayer);
        soldierPlayer.SetActive(player == soldierPlayer);
        grannyPlayer.SetActive(player == grannyPlayer);
    }
}
