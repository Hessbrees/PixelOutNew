using UnityEngine;
using Zenject;

public class DefaultInstaller : MonoInstaller<DefaultInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ILogoUI>().To<LogoUI>().AsSingle();
        Container.Bind<IMainMenuUI>().To<MainMenuUI>().AsSingle();
        Container.Bind<IDifficulty>().To<DifficultyUI>().AsSingle();
        Container.Bind<ILanguageUI>().To<LanguageUI>().AsSingle();
        Container.Bind<ISettingsUI>().To<SettingsUI>().AsSingle();
        Container.Bind<IUpgradesUI>().To<UpgradesUI>().AsSingle();
        Container.Bind<IStatsUI>().To<StatsUI>().AsSingle();
        Container.Bind<IGameSceneUI>().To<GameSceneUI>().AsSingle();
        Container.Bind<IPauseUI>().To<PauseUI>().AsSingle();
        Container.Bind<IFailedScreen>().To<FailedScreenUI>().AsSingle();
        Container.Bind<IWinScreenUI>().To<WinScreenUI>().AsSingle();        
        
        
        Container.Bind<IPlayerControler>().To<PlayerControler>().AsSingle();
        Container.Bind<IEnemyControl>().To<EnemyControl>().AsSingle();
        Container.Bind<IGameManager>().To<GameManager>().AsSingle();

        Container.Bind<IScorePoints>().To<ScorePoints>().AsSingle();

    }
}