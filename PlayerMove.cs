using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;


    // ����
    

    private float xRotation = 0f;

    void Start()
    {
        // ���콺 Ŀ���� ȭ�� �߾ӿ� ����
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Jump();
        CheckGround();
 
        // ���콺 �Է� ó�� (ī�޶� ȸ��)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // ī�޶� ȸ�� ���� (��/�Ʒ�)

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // �̵� �Է� ó��
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // �޸��� �Է� ó��
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;

        // �̵� ����
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //�������� ���� �ش�.
            Rigidbody Rigidbody = transform.GetComponent<Rigidbody>();
            Rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

    void CheckGround()
    {

    }
}