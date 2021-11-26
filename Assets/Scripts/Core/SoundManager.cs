using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class SoundManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public static AudioSource Player;
        public static UnityEvent FlipBitOn = new UnityEvent();
        public static UnityEvent FlipBitOff = new UnityEvent();
        public static UnityEvent CorrectSequence = new UnityEvent();

        public AudioClip FlipOnSound;
        public AudioClip FlipOffSound;
        public AudioClip CorrectSound;

        void Awake()
        {
            Player = gameObject.GetComponent<AudioSource>();
            FlipBitOn.AddListener(PlayFlipOn);
            FlipBitOff.AddListener(PlayFlipOff);
            CorrectSequence.AddListener(PlayOutputCorrect);
        }

        void PlayFlipOn()
        {
            Player.clip = FlipOnSound;
            Player.Play();
        }

        void PlayFlipOff()
        {
            Player.clip = FlipOffSound;
            Player.Play();
        }

        void PlayOutputCorrect()
        {
            Player.clip = CorrectSound;
            Player.Play();
        }
    }
}