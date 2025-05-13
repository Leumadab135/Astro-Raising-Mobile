using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider _energySlider;
    [SerializeField] private TextMeshProUGUI _textSlider;
    [SerializeField] private Jetpack _jetpack;

    void Update()
    {
        _energySlider.value = _jetpack.Energy;
        _textSlider.text = "Altitude: " + ((int)_jetpack.transform.position.y).ToString();
    }
}
