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
    public TextMeshProUGUI MazeEndpoint;
    public TextMeshProUGUI BreadCrumb;

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
    public TextMeshProUGUI pathOnTheLeft;
    

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
        if (SceneManager.GetActiveScene().name == "Challenge 1")
        {
            objective.text = "Objective";
            bankSafe.text = "Safe";
            yourRobot.text = "Your Robot";
            bank.text = "Bank";
            ambulance.text = "Ambulance";
            firstAid.text = "First Aid";
            rulerDermacations.text = "<U>RULER DEMARCATIONS</U>\n" +

         "\tEach thick line on the horizontal ruler is 20m apart.\n" +
         "\tEach thick line on the vertical ruler is 30m apart.\n" +

                 "\tEach unit is in relation to the center of the robot.";


            MainRules.text =
            "<b>Objective- Object Detection:</b> This challenge will test your robot’s ability to recognize objects. The robot must detect an object and transport it to to the right location. The first aid box should go to the Ambulance(20 points) and the safe should go to the Bank(30 points). The objects may or may not swap positions. The robot detects an object by measuring or sensing its height. (First Aid = 50m), (Safe = 76m). The ruler button switches the ruler on and off to help you measure distances. \n\n" +
            "There is 1 minute and 15 seconds on the clock to achieve these tasks. You have unlimited chances to play. Your top score gets saved as your final score.";
            GameFieldHeading.text = "CHALLENGE 1 GAME FIELD";

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
        else if (SceneManager.GetActiveScene().name == "Challenge 2")
        {
            MainRules.text =
           "<b>Objective- FILL THE HOLES:</b> This challenge will test your math skills. With the help of the given dimensions above, help your robot navigate the entire perimeter of each shape. The robot should pass through each purple dot of each shape to cover its perimeter. \n" +
           "Completing each shape fills the hole and scores you 50 points for each shape.\n" +
           "There is 1 minute and 15 seconds on the clock to achieve these tasks. You have unlimited chances to play. Your top score gets saved as your final score.";
            GameFieldHeading.text = "CHALLENGE 2 GAME FIELD";

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
        else if (SceneManager.GetActiveScene().name == "Challenge 3")
        {
            MainRules.text =
           "<b>Objective - ESCAPE THE MAZE:</b> This challenge will test your memory skills. Help your robot make its way to the endpoint marker of the maze to complete this challenge. You can drop breadcrumbs by pressing \"K\" on the keyboard to remember paths taken. You have a limited amount of breadcrumbs(100). You can repick them by pressing \"L\". The Robot can be moved using the arrow keys or \"W\", \"A\", \"S\", \"D\" on the keyboard. \n" +
           "\nCompleting this challenge scores you 100 points.\n" +
           "\nYou have 8 minutes to complete this challenge after the play button has been pressed. You have unlimited tries, but with each try a random maze is given. Your best score will be selected.\n";
            GameFieldHeading.text = "CHALLENGE 3 INTERACTABLES";
            MazeEndpoint.text = "MazeEndpoint";
            BreadCrumb.text = "Bread crumb";
        }
        else if (SceneManager.GetActiveScene().name == "Challenge 4")
        {
            MainRules.text =
           "<b>Objective - ESCAPE THE MAZE 2:</b> This challenge will test your problem solving skills. Help your robot make its way to the endpoint marker of each maze to complete this challenge. You have a limited amount of blocks (resources) you can use. Try to use less blocks to avoid crashing your robot. (The game restarts if your robot crashes). If you use more than 7 blocks and/or make more than 7 changes to your blocks the robot will crush. The red bar on the screen (TEMP%) shows your robots temperature level the greater it increases the closer you get to your robot crushing." +
           "\nCompleting this challenge scores you 100 points.\n" +
           "\nYou have 1 minute 30 seconds to complete two separate mazes of this challenge after the play button has been pressed. Your best score will be selected as your final score.\n";
            GameFieldHeading.text = "CHALLENGE 4 INTERACTABLES";
            MazeEndpoint.text = "MazeEndpoint";
        }
        

            GameplayHeading.text = "GAME PLAY & GENERAL RULES";
            Score.text = "SCORE:";
            Time.text = "TIME:";
            
    }

    private void FR()
    {
        if (SceneManager.GetActiveScene().name == "Challenge 1")
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



            MainRules.text =
            "<b>Objectif - Détection d'objets:</b> Ce défi testera la capacité de votre robot à reconnaître les objets. Le robot doit détecter un objet et le transporter au bon endroit. La trousse de premiers soins doit aller à l'ambulance (20 points) et le coffre-fort doit aller à la banque (30 points). Les objets peuvent ou non changer de position. Le robot détecte un objet en mesurant ou en détectant sa hauteur. (Premiers secours = 50 m), (Sûr = 76 m). Le bouton de la règle active et désactive la règle pour vous aider à mesurer les distances. \n\n" +
            "Il y a 1 minute et 15 secondes sur l'horloge pour accomplir ces tâches. Vous avez des chances illimitées de jouer. Votre meilleur score est enregistré comme score final.";
            GameFieldHeading.text = "CHALLENGE 1 CHAMP DE JEU";

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
        else if (SceneManager.GetActiveScene().name == "Challenge 2")
        {
            MainRules.text =
            "<b>Objectif - REMPLIR LES TROUS:</b> Ce défi mettra à l'épreuve vos compétences en mathématiques. À l'aide des dimensions données ci-dessus, aidez votre robot à parcourir tout le périmètre de chaque forme. Le robot doit passer à travers chaque point violet de chaque forme pour couvrir son périmètre.\n" +
            "Remplir chaque forme remplit le trou et vous rapporte 50 points pour chaque forme.\n" +
            "Il y a 1 minute et 15 secondes sur l'horloge pour accomplir ces tâches. Vous avez des chances illimitées de jouer. Votre meilleur score est enregistré comme score final.";
            GameFieldHeading.text = "CHALLENGE 2 CHAMP DE JEU";

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
        else if (SceneManager.GetActiveScene().name == "Challenge 3")
        {
            MainRules.text =
           "<b> Objectif - ÉCHAPPER DU MAZE: </b> Ce défi testera vos capacités de mémoire. Aidez votre robot à se frayer un chemin jusqu'au marqueur de point final du labyrinthe pour relever ce défi. Vous pouvez supprimer le fil d'Ariane en appuyant sur \"K\" sur le clavier pour vous souvenir des chemins empruntés. Vous avez une quantité limitée de chapelure (100). Vous pouvez les repiquer en appuyant sur \"L\". Le robot peut être déplacé en utilisant les touches fléchées ou \"W\", \"A\", \"S\", \"D\" sur le clavier. \n" +
           "\nTerminer ce défi vous rapporte 100 points.\n" +
           "\nVous avez 8 minutes pour terminer ce défi après avoir appuyé sur le bouton de lecture. Vous avez des essais illimités, mais à chaque essai, un labyrinthe aléatoire est donné. Votre meilleur score sera sélectionné.\n";
            GameFieldHeading.text = "DÉFI 3 INTERACTABLES";
            MazeEndpoint.text = "Point de terminaison du labyrinthe";
            BreadCrumb.text = "Miette de pain";
        }
        else if (SceneManager.GetActiveScene().name == "Challenge 4")
        {
            MainRules.text =
           "<b> Objectif - ÉCHAPPER DU MAZE 2: </b> Ce défi testera vos compétences en résolution de problèmes. Aidez votre robot à atteindre le marqueur de point final de chaque labyrinthe pour relever ce défi. Vous disposez d'un nombre limité de blocs (ressources) que vous pouvez utiliser. Essayez d'utiliser moins de blocs pour éviter de planter votre robot. (Le jeu redémarre si votre robot tombe en panne). Si vous utilisez plus de 7 blocs ou si vous modifiez vos blocs, le robot écrasera. La barre rouge sur l'écran (TEMP%) indique le niveau de température de votre robot, plus il augmente au fur et à mesure que vous vous rapprochez de l'écrasement de votre robot. \n" +
           "\nTerminer ce défi vous rapporte 100 points.\n" +
           "\nVous avez 1 minute 30 secondes pour terminer deux labyrinthes séparés de ce défi après avoir appuyé sur le bouton de lecture. Votre meilleur score sera sélectionné comme votre score final.\n";
            GameFieldHeading.text = "DÉFI 4 INTERACTABLES";
            MazeEndpoint.text = "Point de terminaison du labyrinthe";

            Events.text = "ÉVÉNEMENTS";
            Motion.text = "MOUVEMENT";
            Control.text = "CONTRÔLE";
            when.text = "Lorsque";
            clicked.text = "cliqué";
            move.text = "Déplacer";
            turnRight.text = "Tournez à droite";
            turnLeft.text = "Tournez à gauche";
            height.text = "La taille";
            sound.text = "Sonner";
            ifBlock.text = "si";
            then.text = "ensuite";
            repeat.text = "Répéter";
            times.text = "fois";
            pathOnTheLeft.text = "Chemin à gauche";
        }


        GameplayHeading.text = "GAME PLAY & RÈGLES GÉNÉRALES";
            Score.text = "BUT:";
            Time.text = "TEMPS:";
            
    }

}
