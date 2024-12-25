using UnityEngine;

public class ChangeColorAndMuteSound : MonoBehaviour
{
    public Renderer objectRenderer;
    public AudioSource audioSource;
    private bool isMuted = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) // استجابة للضغط على زرار "Y" على الكيبورد
        {
            if (isMuted)
            {
                // استعادة الصورة إلى حالتها الأصلية
                objectRenderer.enabled = true;
                objectRenderer.material.color = Color.white;

                // تشغيل الصوت
                audioSource.Play();
                isMuted = false;
            }
            else
            {
               
               
                objectRenderer.material.color = Color.black;
                objectRenderer.material.DisableKeyword("_EMISSION");

                // إيقاف الصوت
                audioSource.Stop();
                isMuted = true;
            }
        }
    }
}