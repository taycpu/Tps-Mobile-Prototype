using UnityEngine;
using UnityEngine.UI;

namespace GameSource.Scripts.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Image healthBar;


        public void FillImage(float amount)
        {
            healthBar.fillAmount = amount;
        }
    }
}