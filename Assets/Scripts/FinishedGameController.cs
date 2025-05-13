using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace finishedGame
{
    public class FinishedGameController : MonoBehaviour
    {
        [SerializeField] Button _resetGameButton;
        [SerializeField] Button _exitGameButton;

        // Start is called before the first frame update
        void Start()
        {
            _resetGameButton.onClick.AddListener(ResetGame);
            _exitGameButton.onClick.AddListener(ExitGame);
        }

        private void ResetGame()
        {
            SceneManager.LoadScene("MainMenu");
        }
        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
