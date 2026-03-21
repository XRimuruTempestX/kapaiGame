

using Fantasy.Entitas;
using Fantasy.Entitas.Interface;
using Fantasy.Network;
using MongoDB.Bson.Serialization.Attributes;

public class UserData : Entity, ISupportedSerialize
{
    public string account;
    public int coin;
    public int diamond;
    public List<int> heroList;
    
    [BsonIgnore]
    public Session _session;
    
}