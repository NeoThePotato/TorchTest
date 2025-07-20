using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class LoadTests
{
	private const int MAX_TORCH_COUNT = 100_000;

	private readonly List<Torch> _torches = new(MAX_TORCH_COUNT);

	private IEnumerator SpawnAndLitTorch(int iterations)
	{
		for (int i = 0; i < iterations; i++)
			_torches.Add(UnitTests.CreateTorch());
		yield return null;
		foreach (var t in _torches)
			t.LightUp();
		yield return null;
		foreach (var t in _torches)
			Object.Destroy(t.gameObject);
		_torches.Clear();
	}

	[UnityTest]
	public IEnumerator SpawnAndLitTorch10() => SpawnAndLitTorch(10);

	[UnityTest]
	public IEnumerator SpawnAndLitTorch100() => SpawnAndLitTorch(100);

	[UnityTest]
	public IEnumerator SpawnAndLitTorch1K() => SpawnAndLitTorch(1_000);

	[UnityTest]
	public IEnumerator SpawnAndLitTorch10K() => SpawnAndLitTorch(10_000);

	[UnityTest]
	public IEnumerator SpawnAndLitTorch100K() => SpawnAndLitTorch(100_000);

}
