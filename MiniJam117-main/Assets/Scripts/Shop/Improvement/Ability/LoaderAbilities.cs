using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoaderAbilities : MonoBehaviour
{
    [SerializeField] private List<Ability> _allAbilities;
    private List<Ability> _loadedAbilities = new List<Ability>();
    private bool _isLoaded;
    public List<Ability> LoadedAbilities => _loadedAbilities;
    public List<Ability> AllAbilities => _allAbilities;
    public bool IsLoaded => _isLoaded;

    private void Awake() 
   {
    List<string> names = LoadAbility();
    if (names.Count <= 0)
    {
       names = GetDefaultAbilities();
       _isLoaded = true;
    }
     foreach (var name in names)
     {
       Debug.Log(name);
       int index = name.IndexOf('_');
       int price = int.Parse(name.Remove(0,index + 1));
       string type = name.Substring(0,index);
       Ability ability = _allAbilities.Where(e=>e.CurrentTypeOfStat.ToString() == type).Where(e=>e.Price == price).FirstOrDefault();
      _loadedAbilities.Add(ability);
    }
   }
   public List<string> LoadAbility()
   {
    List<string> names = new List<string>();
    SavableAbilities savableAbilities = Loader<SavableAbilities>.Load(new SavableAbilities());
    if (savableAbilities != null)
    {
        names = savableAbilities.NamesOfAbilities;
    }
    return names;
   }
   public Ability GetCurrentAbility(TypeOfStat typeOfStat)
   {
    return _allAbilities.Find(e=>e.CurrentTypeOfStat == typeOfStat);
   }
   public List<string> GetDefaultAbilities()
   {
    List<string> names = new List<string>();
     List<TypeOfStat> _typeOfStats = _allAbilities.Select(e=>e.CurrentTypeOfStat).Distinct().ToList();
     _typeOfStats.ForEach(e=>names.Add(e + "_" + _allAbilities.Where(a=>a.CurrentTypeOfStat == e).FirstOrDefault().Price));
     return names;
   }
}
