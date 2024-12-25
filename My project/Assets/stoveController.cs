using UnityEngine;

public class StoveController : MonoBehaviour
{
    public ParticleSystem fireParticles; // أضف الـ Particle System هنا
    public AudioSource fireSound; // لتشغيل الصوت أثناء اشتعال النار

    private bool isOn = false; // حالة النار

    void Update()
    {
        // عند الضغط على مفتاح F يتم تشغيل وإيقاف النار
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFire();
        }
    }

    void ToggleFire()
    {
        isOn = !isOn; // تغيير الحالة

        if (isOn)
        {
            fireParticles.Play(); // تشغيل النار
            if (fireSound != null)
            {
                fireSound.Play(); // تشغيل الصوت
            }
        }
        else
        {
            fireParticles.Stop(); // إيقاف النار
            if (fireSound != null)
            {
                fireSound.Stop(); // إيقاف الصوت
            }
        }
    }
}