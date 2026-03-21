using Fantasy.Authentication;
using Fantasy.Entitas;

namespace Hotfix.Gate.Component;

public class CharacterDataComponent : Fantasy.Entitas.Entity
{
    public List<CharacterConfig>?  characterList = new List<CharacterConfig>();
}