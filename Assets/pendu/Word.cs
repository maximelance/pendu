/*
contient le mot à deviner
gère la vérification des lettres propsoées
met à jour l'état du mot à deviner
*/

namespace Assets.pendu
{
    public class Word
    {
        public string WordToGuess { get; set; }

        public string DisplayWord { get; set; }

        public char letter;

        public Word(string word)
        {
            WordToGuess = word;
            DisplayWord = new string('#', word.Length);
        }

        public void Clear()
        {
            WordToGuess = "";
            DisplayWord = new string('?', 5);
        }

        public bool IsWordGuessed()
        {
            return WordToGuess == DisplayWord;
        }

        public char GetGuessedLetter()
        {
            return letter;
        }

        public bool CheckUserLetter(string text)
        {
            bool letterFound = false;
            if (IsChar(text))
            {
                for (int i = 0; i < WordToGuess.Length; i++)
                {
                    char lowerWordToGuess = char.ToLower(WordToGuess[i]);
                    char lowerLetter = char.ToLower(letter);

                    if (lowerWordToGuess == lowerLetter)
                    {
                        char[] charArray = DisplayWord.ToCharArray();
                        charArray[i] = WordToGuess[i];
                        DisplayWord = new string(charArray);
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
}