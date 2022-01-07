using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerCounterText;

        private float _timer;
        private bool _timerStopped;

        private void Update()
        {
            if (_timerStopped)
                return;
            
            _timer += Time.deltaTime;
            var seconds = _timer % 60;

            timerCounterText.text = seconds.ToString("N1");
        }

        public void StopTimer() 
            => _timerStopped = true;
    }
}
