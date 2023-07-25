using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class MoveEnemyTests : SceneTestFixture
{
    [UnityTest]
    public IEnumerator MovePeasant_PositionChange_FalseReturn()
    {
        yield return LoadScene("Test_MovePeasant_PositionChanged");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var peasant = Object.FindObjectOfType<Peasant>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(
            player.transform.position == Vector3.zero &&
            peasant.transform.position == new Vector3(2, 0));
    }

    [UnityTest]
    public IEnumerator KillPeasant_PeasantDeath_FalseReturn()
    {
        yield return LoadScene("Test_KillPeasant_PeasantDeath");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var peasant = Object.FindObjectOfType<Peasant>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(peasant == null);
    }
}
