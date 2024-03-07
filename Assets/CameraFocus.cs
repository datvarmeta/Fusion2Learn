using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Camera mainCamera; // Tham chiếu đến Main Camera
    public Transform targetObject; // Đối tượng bạn muốn camera tập trung vào
    public Vector3 offset; // Khoảng cách giữa camera và đối tượng
    public float smoothTime = 0.3f; // Thời gian để làm mượt chuyển động camera

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (targetObject != null)
        {
            // Tính toán vị trí mới cho camera dựa trên đối tượng và offset
            Vector3 targetPosition = targetObject.position + offset;

            // Sử dụng SmoothDamp để di chuyển camera một cách mượt mà
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPosition, ref velocity, smoothTime);

            // Đặt camera hướng về đối tượng
            mainCamera.transform.rotation = Quaternion.Euler(targetObject.forward.x, targetObject.forward.y, targetObject.forward.z);
        }
    }

}
