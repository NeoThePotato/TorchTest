using System.Buffers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTorchInteractor : MonoBehaviour
{
	private const int DEFAULT_ARRAY_SIZE = 64;
	private static ArrayPool<Collider> Pool => ArrayPool<Collider>.Shared;

	public float interactionRange = 2f;

	void Update()
	{
		if (Keyboard.current.eKey.wasPressedThisFrame)
			Interact();
	}

	public void Interact()
	{
		var colliders = Pool.Rent(DEFAULT_ARRAY_SIZE);
		Physics.OverlapSphereNonAlloc(transform.position, interactionRange, colliders);
		foreach (var collider in colliders)
		{
			if (collider && collider.TryGetComponent<Torch>(out var torch) && !torch.isLit)
				torch.LightUp();
		}
		Pool.Return(colliders);
	}
}
