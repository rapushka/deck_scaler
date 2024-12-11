using MoreMountains.Feedbacks;
using UnityEngine;

namespace DeckScaler
{
    public class FloatingNumberView : MonoBehaviour
    {
        [SerializeField] private MMF_Player _feedbackPlayer;

        public void Play(float number)
        {
            _feedbackPlayer.PlayFeedbacks(transform.localPosition, number);
        }
    }
}