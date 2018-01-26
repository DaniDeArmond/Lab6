using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab6
{
    class Program
    {
        public static string[] GetWords(string Sentence)
        {
            string[] SentenceWord;
            SentenceWord = Sentence.Split(' ');
            return SentenceWord;
        }

        public static bool ValidateInput(string Word)
        {
            bool AllLetters = true;

            if (Regex.IsMatch(Word, @"^[A-z\']+$")!=true)
            {
                AllLetters = false;
            }
            return AllLetters;
        }

        public static string EnglishToPigLatin(string Word)
        {

            Char[] Vowels = new Char[10] { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
            int IndexValue = Word.IndexOfAny(Vowels);
            string Word1, Word2;

            if (IndexValue == 0)
            {
                Word += "way";
                return Word;
            }
            else if(IndexValue < 0)
            {
                return Word;
            }
            else
            {
                Word1 = Word.Substring(IndexValue);
                Word2 = Word.Remove(IndexValue);
                Word = (Word1 + Word2 + "ay");
                return Word;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                string UserInput, Answer, DoAgain, Substring;
                bool Repeat = true;
                string[] MyArray;
                List<string> MyList, FailList;

                Console.WriteLine("Welcome to the Pig Latin Translator!");

                while (Repeat == true)
                {
                    MyList = new List<string>();
                    FailList = new List<string>();

                    Console.WriteLine("What English word would you like to translate into Pig Latin?");
                    UserInput = Console.ReadLine();
                    Console.WriteLine();

                    UserInput = UserInput.Trim(' ');

                    if (Regex.IsMatch(UserInput, @"\s+") != true)
                    {
                        if (ValidateInput(UserInput) == true)
                        {
                            Answer = EnglishToPigLatin(UserInput);
                            Console.WriteLine(Answer);
                        }
                        else
                        {
                            Answer = UserInput;
                            Console.WriteLine(Answer);
                        }
                    }
                    else
                    {
                        MyArray = GetWords(UserInput);

                        foreach (string sub in MyArray)
                        {
                            if (ValidateInput(sub) == true)
                            {
                                Substring = EnglishToPigLatin(sub);
                                MyList.Add(Substring);
                            }
                            else
                            {
                                FailList.Add(sub);
                            }

                        }
                        if (FailList.Count > 0)
                        {
                            Answer = UserInput;
                            Console.WriteLine(Answer);
                        }
                        else
                        {
                            foreach (string word in MyList)
                            {
                                Console.Write(word + " ");
                            }
                        }
                    }

                    Console.WriteLine("Would you like to translate another word? (Y or N)");
                    DoAgain = Console.ReadLine();

                    if (string.Compare(DoAgain, "Y", true) != 0)
                    {
                        Console.WriteLine("Goodbye!");
                        Repeat = false;
                        Console.Read();
                    }
                }
            }
            catch (Exception error1)
            {
                Console.WriteLine(error1.ToString());
                Console.Read();
            }            
        }
    }
}
