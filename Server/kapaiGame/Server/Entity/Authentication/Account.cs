using System.Text.Json.Serialization;
using Fantasy.Entitas;
using Fantasy.Entitas.Interface;
using Fantasy.Network;

namespace Fantasy.Authentication;

public class Account : Entity, ISupportedSerialize
{
    public string account;
    public string password;
    public long createTime;
    
    public List<CharacterConfig> myCjaracyerList;
}