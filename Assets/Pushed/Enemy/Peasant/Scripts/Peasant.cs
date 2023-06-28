public class Peasant : AEnemy
{
    protected override void CantMove()
    {
        Death();
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }
}
