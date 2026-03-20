using Fantasy;
using Fantasy.Async;
using Fantasy.Authentication;
using Fantasy.Event;
using Hotfix.Tools;

namespace Hotfix;

public sealed class OnSceneCreate_Init : AsyncEventSystem<OnCreateScene>
{
    protected override async FTask Handler(OnCreateScene self)
    {
        switch (self.Scene.SceneType)
        {
            case SceneType.Authentication:
                self.Scene.AddComponent<AuthenticationComponent>();
                self.Scene.AddComponent<EncryptHelperComponent>();
                string privateKey;
                string publicKey;
                break;
        }
        
        await FTask.CompletedTask;

    }
}