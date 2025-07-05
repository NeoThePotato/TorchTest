using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class IntegrationTests
{
	private PlayerTorchInteractor _player;
	private Torch _torch;

	[UnitySetUp]
	public IEnumerator SetUp()
	{
		yield return null;
		_player = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<PlayerTorchInteractor>();
		_player.interactionRange = 1f;
		var torchGo = GameObject.CreatePrimitive(PrimitiveType.Cube);
		_torch = torchGo.AddComponent<Torch>();
	}

	public IEnumerator TearDown()
	{
		yield return null;
		Object.Destroy(_player.gameObject);
		Object.Destroy(_torch.gameObject);
	}

	[UnityTest]
	public IEnumerator TorchLitByPlayerInteraction()
	{
		yield return null;
		_player.transform.position = _torch.transform.position;
		_player.Interact();
		Assert.IsTrue(_torch.isLit, "Torch was not lit by player interaction.");
	}

	[UnityTest]
	public IEnumerator TorchStaysLitAfterAnotherInteraction()
	{
		yield return TorchLitByPlayerInteraction();
		_player.Interact();
		Assert.IsTrue(_torch.isLit, "Torch was was unlit by player interaction.");
	}

	[UnityTest]
	public IEnumerator TorchStaysOnWhenPlayerLeavesRange()
	{
		yield return TorchLitByPlayerInteraction();
		_player.transform.position += new Vector3(1000f, 0f, 0f);
		Assert.IsTrue(_torch.isLit, "Torch was was unlit when player left the torch range.");
	}
}
