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
        AMMO_BOX, DEAD_CIVILIAN, DEAD_SOLDIER
    }
    public string dictatorMissionOrder;
    public string rebelsMissionOrder;
    
    public string dictatorThoughtsIfSuccess;
    public string rebelsThoughtsIfSuccess;
    public string rebelsThoughtsIfFailure;
    public string dictatorThoughtsIfFailure;

    public List<MissionProp> missionProps;


    public void CalculScore(List<PhotoProp> props, ref string dictatorThoughts, ref string rebelsThoughts)
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
        }
        else if(dictatorScore < rebelsScore)
        {
            dictatorThoughts = dictatorThoughtsIfFailure;
            rebelsThoughts = rebelsThoughtsIfSuccess;
        }
        else
        {
            dictatorThoughts = dictatorThoughtsIfFailure;
            rebelsThoughts = rebelsThoughtsIfFailure;
        }
    }

}
