using System;

namespace EPAM
{
    public class Substring
    {
        public string[] SplitString(string sentence)
        {
            return sentence.Split(" ");
        }
        public string LongestSubstring(string[] inputWords)
        {
            string substr = "", answ = "";

            InputValidation(inputWords);

            foreach (var word in inputWords)
            {
                for (var i = 0; i < word.Length; i++)
                {
                    if (!substr.Contains(word[i]))
                    {
                        substr += word[i];
                    }
                    else
                    {
                        substr = word[i].ToString();
                    }
                    if (answ.Length < substr.Length)
                    {
                        answ = substr;
                    }
                }
                substr = "";
            }
            return answ;
        }

        private void InputValidation(string[] inputWords)
        {
            if (inputWords == null || string.IsNullOrEmpty(inputWords[0]) || string.IsNullOrWhiteSpace(inputWords[0])) 
            {
                throw new ArgumentNullException();
            }
        }

        public string LongestSubstringWithDigits(string[] inputWords)
        {
            string substr = "", answ = "";

            InputValidation(inputWords);

            foreach (var word in inputWords)
            {
                for (var i = 0; i < word.Length; i++)
                {
                    if (Char.IsDigit(word[i]))
                    {
                        if (!substr.Contains(word[i]))
                        {
                            substr += word[i];
                        }
                        else
                        {
                            substr = word[i].ToString();
                        }
                    }
                    else
                    {
                        substr = "";
                    }
                    if (answ.Length < substr.Length)
                    {
                        answ = substr;
                    }
                }
                substr = "";
            }
            return answ;
        }

        public string LongestSubstringWithLetters(string[] inputWords)
        {
            string substr = "", answ = "";

            InputValidation(inputWords);

            foreach (var word in inputWords)
            {
                for (var i = 0; i < word.Length; i++)
                {
                    if (Char.IsLetter(word[i]))
                    {
                        if (!substr.Contains(word[i]))
                        {
                            substr += word[i];
                        }
                        else
                        {
                            substr = word[i].ToString();
                        }
                    }
                    else
                    {
                        substr = "";
                    }
                    if (answ.Length < substr.Length)
                    {
                        answ = substr;
                    }
                }
                substr = "";
            }
            return answ;
        }
    }
}

