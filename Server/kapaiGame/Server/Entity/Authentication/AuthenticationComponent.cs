using Fantasy.Entitas;

namespace Fantasy.Authentication;

public class AuthenticationComponent : Entitas.Entity
{
    public Dictionary<int,PlayerSession> _cachedAccounts = new Dictionary<int, PlayerSession>();
}