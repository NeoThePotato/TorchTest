using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBind : MonoBehaviour
{
	public CharacterController characterController;
	public float speed = 5f;
	private Vector2 input;

	public void OnMove(InputAction.CallbackContext context)
	{
		input = context.ReadValue<Vector2>();
	}

	public void FixedUpdate()
	{
		characterController.Move(new Vector3(input.x, 0f, input.y) * Time.deltaTime * speed);
	}
}
