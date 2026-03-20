using Fantasy.Entitas;
using Fantasy.Network;

namespace Fantasy.Authentication;

public class PlayerSession : Entity
{
    public string account;
    
    public string passWord;
    
    public Session _session;
}