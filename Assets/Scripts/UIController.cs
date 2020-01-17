using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject winInterface;
    [SerializeField] GameObject playerDiedInterface;

    void OnEnable()
    {
        Player.OnPlayerDied += OnPlayerDied;
        LevelController.OnWin += OnWinGame;
    }

    void OnDisable()
    {
        Player.OnPlayerDied -= OnPlayerDied;
        LevelController.OnWin -= OnWinGame;
    }

    void OnPlayerDied()
    {
        playerDiedInterface.SetActive(true);
    }

    void OnWinGame()
    {
        winInterface.SetActive(true);
    }
}
