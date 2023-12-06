namespace Utils
{
    public static class StringExtensions
    {
        public static int CountCharOccurrences(this string str, char chr)
        {
            // Primera implementación
            //int count = 0;

            //foreach (char c in str)
            //{
            //    if (c == chr)
            //        count++;
            //}

            //return count;

            
            // Implementación final, luego de haber escrito los unit tests y hacer un refactor
            return str.Count(c => char.ToLowerInvariant(c) == char.ToLowerInvariant(chr));
        }
    }
}
