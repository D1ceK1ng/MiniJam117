using System.Linq;
using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverAbility : MonoBehaviour
{
     private List<ImprovementStats> _listOfImprovementStats = new List<ImprovementStats>();
    [SerializeField] private LoaderAbilities _loaderAbilities;
    private void OnEnable() 
    {
        _listOfImprovementStats = FindObjectsOfType<ImprovementStats>().ToList();
        _listOfImprovementStats.ForEach(e=>e.OnBuyAbility += TrySavingAbility);
        if (_loaderAbilities.IsLoaded)
        {
            Save(_loaderAbilities.GetDefaultAbilities());
        }
    }
    private void TrySavingAbility(Ability ability)
    {
       List<string> namesOfAbilities = _loaderAbilities.LoadAbility();
       for (int i = 0; i < namesOfAbilities.Count; i++)
       {
        int index = namesOfAbilities[i].IndexOf('_');
        string type = namesOfAbilities[i].Substring(0,index);
        if (type == ability.CurrentTypeOfStat.ToString())
        {
            string price = namesOfAbilities[i].Remove(0,index + 1);
            namesOfAbilities[i] = namesOfAbilities[i].Replace(price,ability.Price.ToString());
        }
       }
       namesOfAbilities.ForEach(e=>Debug.Log(e + " after saving"));
       Save(namesOfAbilities);     
    }
    public void Save(List<string> listOfItems)
    {
        Saver<SavableAbilities>.Save(new SavableAbilities(listOfItems));
    }
    private void OnDisable() 
    {
        _listOfImprovementStats.ForEach(e=>e.OnBuyAbility -= TrySavingAbility);
    }
}
