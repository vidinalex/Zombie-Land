using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [Space(5)]
    [SerializeField] private LayerMask aimLayerMask;
    [SerializeField] private Animator animator;

    private void Update()
    {
        AimTowardsMouse();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }

        float velZ = Vector3.Dot(movement.normalized, transform.forward);
        float velX = Vector3.Dot(movement.normalized, transform.right);

        animator.SetFloat("VelocityZ", velZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velX, 0.1f, Time.deltaTime);
    }

    private void AimTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, aimLayerMask))
        {
            var direction = hitInfo.point - transform.position;
            direction.y = 0f;
            direction.Normalize();
            transform.forward = direction;
        }
    }
}