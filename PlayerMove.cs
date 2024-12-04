using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;


    // 점프
    

    private float xRotation = 0f;

    void Start()
    {
        // 마우스 커서를 화면 중앙에 고정
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Jump();
        CheckGround();
 
        // 마우스 입력 처리 (카메라 회전)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // 카메라 회전 제한 (위/아래)

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // 이동 입력 처리
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // 달리기 입력 처리
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;

        // 이동 실행
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //위쪽으로 힘을 준다.
            Rigidbody Rigidbody = transform.GetComponent<Rigidbody>();
            Rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

    void CheckGround()
    {

    }
}