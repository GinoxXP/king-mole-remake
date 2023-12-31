using Zenject;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ClassicMode>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LoadScene>().FromComponentInHierarchy().AsSingle();
    }
}