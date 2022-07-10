using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HelloEditorTest
{
    [Test]
    public void HelloEditorTestSimplePasses()
    {
        HelloEdit helloEdit = ScriptableObject.CreateInstance<HelloEdit>();
        Assert.AreEqual("Hello Play Mode", helloEdit.Speak());
    }

    [UnityTest]
    public IEnumerator HelloEditorTestWithEnumeratorPasses()
    {
        HelloEdit helloEdit = ScriptableObject.CreateInstance<HelloEdit>();
        yield return null;
        Assert.AreEqual("Hello Play Mode", helloEdit.Speak());
    }
}
