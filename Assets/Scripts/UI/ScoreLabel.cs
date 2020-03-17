using TMPro;
using UnityEngine;
using Zenject;

namespace Project
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreLabel : MonoBehaviour
    {
        [SerializeField]
        private string format = "Score : {0}";

        [Inject] private Play.GameManager gameManager;

        private TMP_Text label;

        private void Awake()
        {
            this.label = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            this.label.text = string.Format(this.format, gameManager.Score);
        }
    }
}
