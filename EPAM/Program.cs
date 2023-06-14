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
            var substr = new Substring();
            var words = substr.SplitString(sentance);


            Console.WriteLine(substr.LongestSubstring(words));
        }
    }
}