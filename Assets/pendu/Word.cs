/*
contient le mot à deviner
gère la vérification des lettres propsoées
met à jour l'état du mot à deviner
*/
using UnityEngine;

//namespace MyProject
//{

public class Word
{
    private string wordToGuess;

    private string displayWord;

    private char letter;

    public Word(string word)
    {
        wordToGuess = word;
        displayWord = new string('#', word.Length);
    }

    public void Clear()
    {
        wordToGuess = "";
        displayWord = "";

    }

    public bool IsWordGuessed()
    {
        return wordToGuess == displayWord;
    }

    public string GetDisplayWord()
    {
        return displayWord;
    }

    public string GetGuessingWord()
    {
        return wordToGuess;
    }

    public char GetGuessedLetter()
    {
        return letter;
    }

    public  bool CheckUserLetter(string text) 
    {
        bool letterFound = false;
        if (IsChar(text))
        {
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                char lowerWordToGuess = char.ToLower(wordToGuess[i]);
                char lowerLetter = char.ToLower(letter);

                if (lowerWordToGuess == lowerLetter)
                {
                    char[] charArray = displayWord.ToCharArray();
                    charArray[i] = wordToGuess[i];
                    displayWord = new string(charArray);
                    letterFound = true;
                }
            }
        }
        return letterFound;
    }
    bool IsChar(string text)
    {
            bool isChar = false;
            isChar = char.TryParse(text, out letter);
            return isChar;
    }
}

//}