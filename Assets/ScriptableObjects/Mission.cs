using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Scriptable Objects/Mission")]
public class Mission : ScriptableObject
{
    [Serializable]
    public struct MissionProp
    {
        public PhotoProp prop;
        public int dictatorPoints; 
        public int rebelsPoints;
    }
    public enum PhotoProp
    {
        SOLDIER, CIVILIAN, REBEL, VILLAGE, FARM, POLICE_MAN, ANIMAL, FIRE, HOSPITAL, FLAG_DICTATOR, FLAG_REBEL, 
        AMMO_BOX, DEAD_CIVILIAN, DEAD_SOLDIER, FOOD, ALCOOL, WHEEL_CHAIR, MEDICINE, WEAPON, DOG, MONEY, STREET, DRUG_FIELD, SCHOOL, HOUSE, STORE,
        ENFANT
    }

    [Header("Dictateur")]
    public string dictatorNouvelle;
    public string dictatorOrdre;

    public string dictatorThoughtsIfSuccess;
    public string dictatorThoughtsIfFailure;


    [Header("Rebels")]
    public string rebelNouvelle;
    public string rebelOrdre;

    public string rebelsThoughtsIfSuccess;
    public string rebelsThoughtsIfFailure;

    public List<MissionProp> missionProps;


    public void CalculScore(List<PhotoProp> props, ref string dictatorThoughts, ref string rebelsThoughts, ref string journal)
    {
        int dictatorScore = 0;
        int rebelsScore = 0;
        foreach (var prop in props)
        {
            MissionProp missionProp = missionProps.Where(x => x.prop == prop).ToList()[0];
            dictatorScore +=missionProp.dictatorPoints;
            rebelsScore +=missionProp.rebelsPoints;
        }
        if(dictatorScore > rebelsScore)
        {
            dictatorThoughts = dictatorThoughtsIfSuccess;
            rebelsThoughts = rebelsThoughtsIfFailure;
            journal = dictatorNouvelle;
        }
        else if(dictatorScore < rebelsScore)
        {
            dictatorThoughts = dictatorThoughtsIfFailure;
            rebelsThoughts = rebelsThoughtsIfSuccess;
            journal = rebelNouvelle;
        }
        else
        {
            dictatorThoughts = dictatorThoughtsIfFailure;
            rebelsThoughts = rebelsThoughtsIfFailure;
        }
    }

}
