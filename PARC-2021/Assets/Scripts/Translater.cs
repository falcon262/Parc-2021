using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Translater : MonoBehaviour
{
    public TextMeshProUGUI objective;
    public TextMeshProUGUI bankSafe;
    public TextMeshProUGUI yourRobot;
    public TextMeshProUGUI ambulance;
    public TextMeshProUGUI bank;
    public TextMeshProUGUI firstAid;
    public TextMeshProUGUI rulerDermacations;

    public TextMeshProUGUI GameplayHeading;
    public TextMeshProUGUI MainRules;
    public TextMeshProUGUI GameFieldHeading;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Time;
    public TextMeshProUGUI Events;
    public TextMeshProUGUI Motion;
    public TextMeshProUGUI Control;
    public TextMeshProUGUI Sound;
    public TextMeshProUGUI Operators;
    public TextMeshProUGUI LogicGates;
    public TextMeshProUGUI Variables;
    public TextMeshProUGUI Scripts;
    public TextMeshProUGUI Blocks;

    public TextMeshProUGUI when;
    public TextMeshProUGUI clicked;
    public TextMeshProUGUI move;
    public TextMeshProUGUI Rotate;
    public TextMeshProUGUI degree;
    public TextMeshProUGUI turn;
    public TextMeshProUGUI turnRight;
    public TextMeshProUGUI turnLeft;
    public TextMeshProUGUI Face;
    public TextMeshProUGUI ReleaseObject;
    public TextMeshProUGUI CarryObject;
    public TextMeshProUGUI ifBlock;
    public TextMeshProUGUI then;
    public TextMeshProUGUI repeat;
    public TextMeshProUGUI times;
    public TextMeshProUGUI repeatForever;
    public TextMeshProUGUI repeatUntil;
    public TextMeshProUGUI wait;
    public TextMeshProUGUI seconds;
    public TextMeshProUGUI playSound;
    public TextMeshProUGUI height;
    public TextMeshProUGUI sound;
    

    private void Start()
    {
        if (Controller.GetIsEnglish())
        {
            EN();
        }
        else if (!Controller.GetIsEnglish())
        {
            FR();
        }
    }

    private void EN()
    {
        objective.text = "Objective";
        bankSafe.text = "Safe";
        yourRobot.text = "Your Robot";
        bank.text = "Bank";
        ambulance.text = "Ambulance";
        firstAid.text = "First Aid";
        rulerDermacations.text = "<U>RULER DEMARCATIONS</U>\n"+

     "\tEach thick line on the horizontal ruler is 20m apart.\n"+
     "\tEach thick line on the vertical ruler is 30m apart.\n" +

             "\tEach unit is in relation to the center of the robot.";

            GameplayHeading.text = "GAME PLAY & GENERAL RULES";
            MainRules.text =
            "<b>Objective- Object Detection:</b> This challenge will test your robot’s ability to recognize objects. The robot must detect an object and transport it to to the right location. The first aid box should go to the Ambulance(20 points) and the safe should go to the Bank(30 points). The objects may or may not swap positions. The robot detects an object by measuring or sensing its height. (First Aid = 50m), (Safe = 76m). The ruler button switches the ruler on and off to help you measure distances. \n\n"+
            "There is 1 minute and 15 seconds on the clock to achieve these tasks. You have unlimited chances to play. Your top score gets saved as your final score.";
            GameFieldHeading.text = "CHALLENGE 1 GAME FIELD";
            Score.text = "SCORE:";
            Time.text = "TIME:";
            Events.text = "EVENTS";
            Motion.text = "MOTION";
            Control.text = "CONTROL";
            Sound.text = "SOUND";
            Operators.text = "OPERATORS";
            LogicGates.text = "LOGIC GATES";
            Variables.text = "VARIABLES";
            Scripts.text = "SCRIPTS";
            Blocks.text = "BLOCKS";

        when.text = "When";
        clicked.text = "clicked";
        move.text = "Move";
        Rotate.text = "Rotate";
        degree.text = "degree";
        turn.text = "Turn";
        turnRight.text = "Turn Right";
        turnLeft.text = "Turn Left";
        Face.text = "Face";
        ReleaseObject.text = "Release Object";
        CarryObject.text = "Carry Object";
        ifBlock.text = "if";
        then.text = "then";
        repeat.text = "Repeat";
        times.text = "times";
        repeatForever.text = "Repeat Forever";
        repeatUntil.text = "Repeat Until";
        wait.text = "Wait";
        seconds.text = "seconds";
        playSound.text = "Play sound";
        height.text = "Height";
        sound.text = "Sound";
    }

    private void FR()
    {
        objective.text = "Objectif";
        bankSafe.text = "Coffre-fort de banque";
        yourRobot.text = "Robot";
        bank.text = "Banque";
        ambulance.text = "Ambulance";
        firstAid.text = "Premiers secours";
        rulerDermacations.text = "<U>DÉMARCATIONS DE RÈGLES</U>\n" +

     "\tChaque ligne épaisse de la règle horizontale est distante de 20 m.\n" +
     "\tChaque ligne épaisse de la règle verticale est distante de 30 m.\n" +

             "\tChaque unité est en relation avec le centre du robot.";


        GameplayHeading.text = "GAME PLAY & RÈGLES GÉNÉRALES";
            MainRules.text =
            "<b>Objectif - Détection d'objets:</b> Ce défi testera la capacité de votre robot à reconnaître les objets. Le robot doit détecter un objet et le transporter au bon endroit. La trousse de premiers soins doit aller à l'ambulance (20 points) et le coffre-fort doit aller à la banque (30 points). Les objets peuvent ou non changer de position. Le robot détecte un objet en mesurant ou en détectant sa hauteur. (Premiers secours = 50 m), (Sûr = 76 m). Le bouton de la règle active et désactive la règle pour vous aider à mesurer les distances. \n\n" +
            "Il y a 1 minute et 15 secondes sur l'horloge pour accomplir ces tâches. Vous avez des chances illimitées de jouer. Votre meilleur score est enregistré comme score final.";
            GameFieldHeading.text = "CHALLENGE 1 CHAMP DE JEU";
            Score.text = "BUT:";
            Time.text = "TEMPS:";
            Events.text = "ÉVÉNEMENTS";
            Motion.text = "MOUVEMENT";
            Control.text = "CONTRÔLE";
            Sound.text = "DU SON";
            Operators.text = "LES OPÉRATEURS";
            LogicGates.text = "LOGIC GATES";
            Variables.text = "VARIABLES";
            Scripts.text = "SCRIPTS";
            Blocks.text = "BLOCS";
        when.text = "Lorsque";
        clicked.text = "cliqué";
        move.text = "Déplacer";
        Rotate.text = "Tourner";
        degree.text = "degré";
        turn.text = "Tourner";
        turnRight.text = "Tournez à droite";
        turnLeft.text = "Tournez à gauche";
        Face.text = "Visage";
        ReleaseObject.text = "Déposer un objet";
        CarryObject.text = "Porter un objet";
        ifBlock.text = "si";
        then.text = "ensuite";
        repeat.text = "Répéter";
        times.text = "fois";
        repeatForever.text = "Répéter pour toujours";
        repeatUntil.text = "Répète jusqu'à";
        wait.text = "Attendre";
        seconds.text = "secondes";
        playSound.text = "Jouer son";
        height.text = "La taille";
        sound.text = "Sonner";
    }

}
