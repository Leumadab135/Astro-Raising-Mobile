using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private AudioSource _caveAmbient;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (_playerTransform.position.y > 279)
        {
            _caveAmbient.Stop();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");

        if (_playerTransform.position.y > 390)
            SceneManager.LoadScene("Win");
    }
}
