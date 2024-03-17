using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonData : MonoBehaviour
{
    //On déclare les variables pour "choisir" notre pokémon (nom, hp, attaque, défense, poids, faiblesses et résistances).
    [SerializeField]private string Pokemon_Name = "Charizard";
    [SerializeField]private int Pokemon_baseHp = 360;
    private int currentHp = 0;
    [SerializeField]private int Pokemon_atk = 84;
    [SerializeField]private int Pokemon_def = 74;
    private int statsPoints = 0;
    [SerializeField]private float Pokemon_weight = 90.5f;
    public enum TypePokemon {  //On déclare un enumérateur pour les types existants de pokémon.
    Normal,
    Fire, 
    Water, 
    Grass, 
    Electric,
    Ice,
    Fighting,
    Poison, 
    Ground, 
    Flying, 
    Psychic, 
    Bug, 
    Rock, 
    Ghost, 
    Dark, 
    Dragon, 
    Steel, 
    Fairy 
    };
    [SerializeField] private TypePokemon[] Pokemon_weaknesses = {TypePokemon.Water, TypePokemon.Electric}; //On déclare un tableau pour les faiblesses de notre pokémon avec comme référence l'énumérateur "Type". On utilise le mot clé "SerializeField" pour que ces tableaux soient visibles dans l'inspecteur.
    [SerializeField] private TypePokemon[] Pokemon_resistances = {TypePokemon.Fire, TypePokemon.Grass, TypePokemon.Bug, TypePokemon.Steel, TypePokemon.Fairy, TypePokemon.Fighting}; //On déclare un tableau pour les résistances de notre pokémon avec comme référence l'énumérateur "Type".
    [SerializeField] private TypePokemon[] Pokemon_Type = {TypePokemon.Grass}; //On déclare un tableau pour les types de notre pokémon avec comme référence l'énumérateur "Type".

    void InitCurrentLife()  //On initialise la vie actuelle du pokémon.
            {
                currentHp = Pokemon_baseHp;
            }
    
    void InitStatsPoints() //On initialise les points de stats du pokémon.
        {
            statsPoints = Pokemon_baseHp + Pokemon_atk + Pokemon_def;
        }

    void Awake() //On appelle les fonctions d'initialisation dans la fonction Awake.
        {
            InitCurrentLife();
            InitStatsPoints();
        }
    
    
    // Start is called before the first frame update
    void Start()
    {
        void displayName() //On crée une fonction pour afficher les informations du pokémon.
        {
            Debug.Log("Name: " + Pokemon_Name);
        }
        void displayBaseHp(){
            Debug.Log("Base HP: " + Pokemon_baseHp);
        }
        void displayCurrentHp(){
            Debug.Log("Current HP: " + currentHp);
        }
        void displayAtk(){
            Debug.Log("Attack: " + Pokemon_atk);
        }
        void displayDef(){
            Debug.Log("Defense: " + Pokemon_def);
        }
        void displayStatsPoints(){  
            Debug.Log("Stats Points: " + statsPoints);
        }
        void displayWeight(){
            Debug.Log("Weight: " + Pokemon_weight);
        }
        void displayWeaknesses(){
            foreach(TypePokemon str in Pokemon_weaknesses){
                Debug.Log("Weaknesses: " + str);
            }
            
        }
        void displayResistances(){
            foreach(TypePokemon str in Pokemon_resistances){
                Debug.Log("Resistances: " + str);
            }
        }

        void TakeDamage(int damage, TypePokemon typeAttack) //On crée une fonction pour infliger des dégâts au pokémon.
            {
                while (currentHp > 0) //Tant que le pokémon est en vie, on lui inflige des dégâts.
                {   
                for (int i = 0; i < Pokemon_Type.Length; i++) //On parcourt le tableau des types du pokémon.
                    if (typeAttack == Pokemon_weaknesses[i] || typeAttack == Pokemon_weaknesses[i]) //Si le type d'attaque est une faiblesse du pokémon, les dégâts sont doublés.
                    {
                        if (currentHp - damage * 2 <= 0)   //Si les dégâts sont supérieurs à la vie actuelle du pokémon, on met sa vie à 0.
                        {
                            currentHp = 0;
                            break;
                        }
                        else //Sinon, on lui inflige les dégâts.
                        {
                            currentHp -= damage * 2;
                            Debug.Log("Current HP: " + currentHp);
                        }
                    }
                    else if (typeAttack == Pokemon_resistances[i] || typeAttack == Pokemon_resistances[i])  //Si le type d'attaque est une résistance du pokémon, les dégâts sont divisés par 2.
                    {
                        if (currentHp - damage / 2 <= 0)
                        {
                            currentHp = 0;
                            break;
                        }
                        else
                        {
                            currentHp -= damage / 2;
                            Debug.Log("Current HP: " + currentHp);
                        }

                    }
                    else if (damage <= 0) //Si les dégâts sont inférieurs ou égaux à 0, on ne lui inflige pas de dégâts.
                    {
                        Debug.Log("Le pokémon n'a pas pris de dégâts.");
                        break;
                    }
                    
                    else //Sinon, on lui inflige les dégâts normalement.
                    {
                        if (currentHp - damage <= 0)
                        {
                            currentHp = 0;
                            break;
                        }
                        else
                        {
                            currentHp -= damage;
                            Debug.Log("Current HP: " + currentHp);
                        }
                    }
                }
            }
            displayName();  //On appelle les différents "display...()" pour afficher les informations du pokémon.
            displayBaseHp();
            displayCurrentHp();
            displayAtk();
            displayDef();
            displayStatsPoints();
            displayWeight();
            displayWeaknesses();
            displayResistances();
            TakeDamage(50, TypePokemon.Grass); //On appelle TakeDamage() pour infliger des dégâts au pokémon en précisant le type d'attaque et sa puissance.
        }


    int GetAttackDamage()   //On crée une fonction pour obtenir les dégâts d'attaque du pokémon.
        {
            return Pokemon_atk;
        }

    // Update is called once per frame
    void Update()
    {
        void CheckIfPokemonAlive()  //On crée une fonction pour vérifier si le pokémon est en vie.
        {
            if (currentHp <= 0)
            {
                Debug.Log(Pokemon_Name + " is dead");
            }
            else
            {
                Debug.Log(Pokemon_Name + " has " + currentHp + " HP left.");
            }
        }
        CheckIfPokemonAlive();  //On appelle CheckIfPokemonAlive() pour vérifier si le pokémon est en vie.
    }
}

