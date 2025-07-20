using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class FunctionalTests
{
	private PlayerTorchInteractor _player;
	private Torch[] _torches;

	[UnitySetUp]
	public IEnumerator SetUp()
	{
		yield return null;
		_player = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<PlayerTorchInteractor>();
		_player.interactionRange = 1f;
		_torches = new Torch[3];
		for (int i = 0; i < _torches.Length; i++)
		{
			var torchGo = GameObject.CreatePrimitive(PrimitiveType.Cube);
			_torches[i] = torchGo.AddComponent<Torch>();
			torchGo.transform.position = new Vector3(5f, 0f, 0f) * i;
		}
	}

	public IEnumerator TearDown()
	{
		yield return null;
		Object.Destroy(_player.gameObject);
		foreach (var t in _torches)
			Object.Destroy(t.gameObject);
	}

	[UnityTest]
	public IEnumerator TorchesLitByPlayerInteraction()
	{
		foreach (var t in _torches)
		{
			yield return null;
			_player.transform.position = t.transform.position;
			_player.Interact();
		}
		foreach (var t in _torches)
			Assert.IsTrue(t.isLit, "Torch was not lit by player interaction.");
	}

	[UnityTest]
	public IEnumerator TorchesNotLitByPlayerMovingIntoRange()
	{
		foreach (var t in _torches)
		{
			yield return null;
			_player.transform.position = t.transform.position;
		}
		_player.transform.position = Vector3.zero;
		foreach (var t in _torches)
			Assert.IsFalse(t.isLit, "Torch was lit by player moving into range.");
	}
}
