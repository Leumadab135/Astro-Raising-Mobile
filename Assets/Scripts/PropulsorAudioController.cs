using UnityEngine;

public class PropulsorAudioController : MonoBehaviour
{
    private AudioSource propulsorAudio;
    private Animator _animator;
    [field: SerializeField] private ButtonController _flyButtonController;
    private bool _flyButtonEnabled = false;
    void Start()
    {
        propulsorAudio = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_flyButtonController.IsFlying)
        {
            _flyButtonEnabled = true;
        }
        else
        {
            _flyButtonEnabled = false;
        }

            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        bool sidePropulsionL = stateInfo.IsName("SidePropulsorLeft");
        bool sidePropulsionR = stateInfo.IsName("SidePropulsorRight");

        bool shouldPlayAudio = _flyButtonEnabled || sidePropulsionL || sidePropulsionR;

        if (shouldPlayAudio && !propulsorAudio.isPlaying)
        {
            propulsorAudio.Play();
        }
        else if (!shouldPlayAudio && propulsorAudio.isPlaying)
        {
            propulsorAudio.Stop();
        }
    }
}
