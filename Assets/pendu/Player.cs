/*
représente le joueur
stocke les informations sur les lettres déja proposées et les tentatives restantes
*/

using System.Collections.Generic;

namespace Assets.pendu
{
    public class Player
    {
        private List<char> guessedLetters;

        private int attemptsLeft;

        public Player(int attemptsNumber)
        {
            guessedLetters = new List<char>();
            attemptsLeft = attemptsNumber;
        }

        public bool AddGuessedLetter(char letter)
        {
            bool letterGuessing = false;
            if (!guessedLetters.Contains(letter))
            {
                guessedLetters.Add(letter);
                letterGuessing = true;
            }
            return letterGuessing;
        }

        public bool UpdateAttempsLeft(char letter)
        {
            bool attemptsReduced = false;
            if (!guessedLetters.Contains(letter))
            {
                guessedLetters.Add(letter);
                attemptsLeft--;
                attemptsReduced = true;
            }
            return attemptsReduced;
        }

        public bool HasAttemptsLeft()
        {
            return attemptsLeft > 0;
        }

        public int NumberOfAttemptsLeft()
        {
            return attemptsLeft;
        }
    }
}