using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateOnGrab : MonoBehaviour
{
    public float rotationSpeed = 100f; // سرعة التدوير
    private XRGrabInteractable grabInteractable;
    private bool isBeingGrabbed = false;

    private void Start()
    {
        // الحصول على الـ XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();

        // إضافة مستمعين على الأحداث الخاصة بالإمساك
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // لما يتم الإمساك بالـ object
        isBeingGrabbed = true;
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // لما يتم الإفلات من الـ object
        isBeingGrabbed = false;
    }

    private void Update()
    {
        // لو الـ object تحت التفاعل
        if (isBeingGrabbed)
        {
            // تدوير الـ object حول المحور Y (أو اختر المحور اللي تحبه) مع الوقت
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
