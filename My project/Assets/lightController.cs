using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light lampLight; // ضوء اللمبة
    public Renderer lampRenderer; // الكائن الذي يمثل اللمبة
    public Color lightOnColor = Color.white; // لون عند تشغيل الضوء
    public Color lightOffColor = Color.gray; // لون عند إطفاء الضوء
    public Color glowColor = Color.white; // لون الـ Glow عند التشغيل
    public Color noGlowColor = Color.black; // لون الـ Glow عند الإطفاء


    public KeyCode toggleKey = KeyCode.L; // الزر المسؤول عن تشغيل/إيقاف الضوء
    void Start()
    {
        //if (lampLight == null)
        //{
        //    lampLight = GetComponent<Light>(); // محاولة إيجاد الضوء تلقائيًا
        //}
        // التأكد من تعيين المتغيرات
        if (lampLight == null)
        {
            Debug.LogError("Lamp Light is not assigned! Please assign it in the Inspector.");
        }

        if (lampRenderer == null)
        {
            Debug.LogError("Lamp Renderer is not assigned! Please assign it in the Inspector.");
        }

    }
    void Update()
    {
        // التحقق من الضغط على الزر
        if (lampLight != null && Input.GetKeyDown(toggleKey))
        {
            lampLight.enabled = !lampLight.enabled; // تشغيل/إطفاء الضوء
            UpdateGlow(lampLight.enabled);

            if (lampRenderer != null)
            {
                lampRenderer.material.color = lampLight.enabled ? lightOnColor : lightOffColor;
            }
        }
    }


    void UpdateGlow(bool isOn)
    {
        if (lampRenderer != null)
        {
            Material material = lampRenderer.material;

            if (isOn)
            {
                // تشغيل الـ Glow
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", glowColor);
            }
            else
            {
                // إطفاء الـ Glow
                material.DisableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", noGlowColor);
            }
        }
    }

}