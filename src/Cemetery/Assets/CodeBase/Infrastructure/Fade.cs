using BrunoMikoski.AnimationSequencer;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Fade : MonoBehaviour
    {
        [SerializeField] private AnimationSequencerController showTweens;
        [SerializeField] private AnimationSequencerController hideTweens;

        private void Awake() => 
            DontDestroyOnLoad(this);

        public void Show()
        {
            gameObject.SetActive(true);
            showTweens.Play();
        }

        public void Hide()
        {
            hideTweens.Play();
            gameObject.SetActive(false);
        }
    }
}