using UnityEngine;

public class CeilingFanRotator : MonoBehaviour
{
    [Tooltip("Rotation speed in degrees per second")]
    public float rotationSpeed = 50f; // سرعة الدوران
    private bool isRotating = true;   // حالة الدوران: شغال أو متوقف

    void Update()
    {
        // إذا كانت حالة الدوران مفعّلة، قم بتدوير النجفة
        if (isRotating)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        // التبديل بين تشغيل وإيقاف الدوران بالضغط على مفتاح المسافة
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRotating = !isRotating; // تغيير الحالة بين شغال ومتوقف
        }
    }
}