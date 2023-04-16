namespace EPAM
{
    internal class Program
    {
        //For this task I assume that uppercase and lowercase letters are two different characters
        //And if user input will consist of several words we will consider each word separately
        //if there are two or more substrings with unique chars returns the first one
        static void Main(string[] args)
        {
            Console.Write("Please input string: ");
            var sentance = Console.ReadLine();
            var words = sentance.Split(" ");

            Console.WriteLine(LongestSubstringWithUniqueChars(words));
        }

        protected static string LongestSubstringWithUniqueChars(string[] inputWords)
        {
            string substr = "", answ = "";

            if (string.IsNullOrEmpty(inputWords[0]))
                return "Null string";

            foreach (var word in inputWords)
            {
                for (var i = 0; i < word.Length; i++)
                {
                    if (!substr.Contains(word[i]))
                        substr += word[i];
                    else
                        substr = word[i].ToString();

                    if (answ.Length < substr.Length)
                        answ = substr;
                }

                substr = "";
            }

            return answ;
        }
    }
}