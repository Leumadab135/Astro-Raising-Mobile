using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class InGameController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private AudioSource _caveAmbient;
    [SerializeField] private Light2D _finalFloorLight;
    [SerializeField] private float _startIntensity = 60f;
    [SerializeField] private float _endIntensity = 2f;
    [SerializeField] private float _duration =1.5f;

    private void Start()
    {
        Application.targetFrameRate = 60;
        _finalFloorLight.intensity = _startIntensity;
    }
    void Update()
    {
        if (_playerTransform.position.y > 270)
        {
            _caveAmbient.Stop();
            StartCoroutine(DimLight());
        }

        if (Input.GetKeyUp(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");

        if (_playerTransform.position.y > 390)
            SceneManager.LoadScene("Win");
    }

    IEnumerator DimLight()
    {
        float elapsed = 0f;

        while (elapsed < _duration)
        {
            _finalFloorLight.intensity = Mathf.Lerp(_startIntensity, _endIntensity, elapsed / _duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        _finalFloorLight.intensity = _endIntensity;
    }
}
