using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    // الحركة للأمام
    public void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // الحركة للخلف
    public void MoveBackward()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    // الحركة لليمين
    public void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    // الحركة لليسار
    public void MoveLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}