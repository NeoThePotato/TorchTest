using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class UnitTests
{
    private Torch _torch;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
		yield return null;
		_torch = Object.FindFirstObjectByType<Torch>();
        Assert.IsNotNull(_torch, "No active torch found in scene.");
	}

	[UnityTest]
    public IEnumerator TorchStaysLitAfterCallingLightUp()
	{
		yield return null;
		_torch.LightUp();
        Assert.IsTrue(_torch.isLit, "Torch.isLit is not true after calling Torch.LightUp.");
	}

	[UnityTest]
	public IEnumerator TorchIsLitAfterCallingLightUp()
	{
		yield return null;
		_torch.LightUp();
		_torch.LightUp();
		Assert.IsTrue(_torch.isLit, "Torch.isLit is not true after calling Torch.LightUp twice.");
	}

	[UnityTest]
	public IEnumerator LitTorchRendersCorrectly()
	{
		yield return null;
		Assert.IsNotNull(_torch.rend, "Torch has no renderer.");
		Assert.IsNotNull(_torch.rend.material, "Torch.rend has no material.");
		Assert.AreEqual(_torch.rend.material.color, Torch.LIT_COLOR, "Torch renderer has incorrect color.");
	}
}
