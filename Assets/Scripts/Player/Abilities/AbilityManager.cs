using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    static public AbilityManager S;

    public Dictionary<string, Dictionary<int, Ability>> classAbilities;

    public void Start()
    {
        S = this;
        classAbilities = new Dictionary<string, Dictionary<int, Ability>>();
    }

    public void init(TextAsset[] classFiles)
    {
        foreach(TextAsset t in classFiles)
        {
            //dictionary of abilities with their id's
            Dictionary<int, Ability> classStuff = new Dictionary<int, Ability>();

            string name = "";
            //loop through file
            string[] data = t.text.Split('\n');
            for(int i = 0; i < data.Length; i++)
            {
                string[] line = data[i].Split(';');

                if(i == 1)
                {
                    name = line[0];
                }

                if (i > 1)
                {
                    switch (name)
                    {
                        case "Guardian":
                            GuardianAbility PA = new GuardianAbility(line);
                            PA.type = Type.Guardian;
                            classStuff.Add(PA.id, PA);
                            break;
                        case "Mystic":
                            break;
                        case "Fighter":
                            break;
                    }
                }
            }
            classAbilities.Add(name, classStuff);
        }
    }
}
