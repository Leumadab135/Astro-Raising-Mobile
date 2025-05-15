using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixedResolutionMobile : MonoBehaviour
{
    public float _targetWidth = 2160f;
    public float _targetHeight = 1080f;

    private int _lastScreenWidth;
    private int _lastScreenHeight;

    void Start()
    {
        UpdateCamera();
    }

    void Update()
    {
        if (Screen.width != _lastScreenWidth || Screen.height != _lastScreenHeight)
        {
            UpdateCamera();
        }
    }

    void UpdateCamera()
    {
        _lastScreenWidth = Screen.width;
        _lastScreenHeight = Screen.height;

        float targetAspect = _targetWidth / _targetHeight;
        float windowAspect = (float)Screen.width / Screen.height;

        Camera cam = GetComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = _targetHeight / 2f;

        if (windowAspect >= targetAspect)
        {
            // Más ancho: barras negras a los lados
            float scaleWidth = targetAspect / windowAspect;
            cam.rect = new Rect((1f - scaleWidth) / 2f, 0, scaleWidth, 1);
        }
        else
        {
            // Más alto: barras negras arriba/abajo
            float scaleHeight = windowAspect / targetAspect;
            cam.rect = new Rect(0, (1f - scaleHeight) / 2f, 1, scaleHeight);
        }
    }
}

