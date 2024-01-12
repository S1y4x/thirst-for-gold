using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToTexts : MonoBehaviour
{
    public Text text;

    public void Default()
    {
        text.text = "Your goal is to gather 500 gold bricks in as many turns as you like," +
            "however it will be more and more difficult to protect your village with each" +
            "upcoming turn as the number of enemies will constantly increase. Click on each of the elements to learn more";
    }

    public void NextWave()
    {
        text.text = "After a minute since the game started, enemies will attack your village every 20 seconds." +
            "You will lose the game if you don’t have enough warriors to protect the village.";
    }

    public void AssignPeasants()
    {
        text.text = "Once summoned, a peasant is idle, and it’s up to you to assign him to a certain task." +
            "Peasants cannot be reassigned.Each of the harvesting peasants brings two pieces of bread every four seconds." +
            "Each of the mining peasants brings a gold brick every 13 seconds." +
            "Idle peasants don’t provide any goods but consume food at the end of the turn.";
    }

    public void Peasants()
    {
        text.text = "Peasants are non-combatant units.They can either harvest wheat or mine for gold." +
            "Once you have at least one spare piece of bread you can summon a peasant." +
            "Summoning takes three seconds. At this time you will be unable to summon another peasant.";
    }

    public void Knights()
    {
        text.text = "Knights are ordinary military units. They die in battle in the ratio 1:1." +
            "Once you have at least two spare pieces of bread you can summon a knight. Summoning takes five seconds. At this time you will be unable to summon another knight.";
    }

    public void Paladins()
    {
        text.text = "Paladins are advanced military units.They die in battle in the ration 1:3." +
            "Once you have a knight, a brick of gold, and a spare piece of bread, you can train a paladin." +
            "Training takes five seconds and consumes a knight. At this time you will be unable to train another knight."+
            "Sometimes in battle, paladins get wounded. You will have to heal them sparing some food.";
    }

    public void BreadGold()
    {
        text.text = "Every seven seconds your units consume a respective amount of food." +
            "If you run out of food you will not be able to summon any new units." +
            "You need to gather 500 gold to win the game while keeping an eye on food supply.";
    }
}
