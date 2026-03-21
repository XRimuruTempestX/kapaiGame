using Fantasy.Authentication;
using Fantasy.Entitas;

namespace Hotfix.Gate.Component;

public class UserDataComponent : Fantasy.Entitas.Entity
{
    public Dictionary<int,UserData>  userDataDic = new Dictionary<int, UserData>();
}