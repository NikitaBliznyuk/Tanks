using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthUi : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Gradient healthGradient;
    
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetValue(float value)
    {
        image.fillAmount = Mathf.Clamp(value, 0.0f, 1.0f);
        image.color = healthGradient.Evaluate(image.fillAmount);
    }
}
