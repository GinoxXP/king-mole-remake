using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using NUnit.Framework;

public class MovePlayerTests : SceneTestFixture
{
    [UnityTest]
    public IEnumerator MovePlayer_PositionChange_FalseReturn()
    {
        yield return LoadScene("Test_MovePlayer_PositionChanged");

        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        player.SetMoveDirection(Vector2.up);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.down);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.left);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.right);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.right);
        yield return new WaitForSeconds(1.0f);

        var endPosition = player.transform.position;

        Assert.IsTrue(endPosition == new Vector3(1, 0));
    }

    [UnityTest]
    public IEnumerator MovePlayerWithWallDetect_PositionChange_FalseReturn()
    {
        yield return LoadScene("Test_MovePlayerWithWallDetect_PositionChange");

        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        player.SetMoveDirection(Vector2.up);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.left);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.down);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.down);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.down);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.left);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.right);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.down);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector2.right);
        yield return new WaitForSeconds(1.0f);

        var endPosition = player.transform.position;

        Assert.IsTrue(endPosition == new Vector3(1, -2));
    }
}