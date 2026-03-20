using Fantasy.Entitas;
using Fantasy.Entitas.Interface;

namespace Fantasy.Authentication;

public class Account : Entity, ISupportedSerialize
{
    public string account;
    public string password;
    public long createTime;
}