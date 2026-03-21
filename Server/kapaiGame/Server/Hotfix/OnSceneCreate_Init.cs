using Fantasy;
using Fantasy.Async;
using Fantasy.Authentication;
using Fantasy.Event;
using Hotfix.Gate.Component;
using Hotfix.Gate.System;
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
                break;
            case SceneType.Gate:
                var characterCmp =  self.Scene.AddComponent<CharacterDataComponent>();
                self.Scene.AddComponent<UserDataComponent>();
                characterCmp.LoadCharacterConfig();
                break;
        }
        
        await FTask.CompletedTask;

    }
}