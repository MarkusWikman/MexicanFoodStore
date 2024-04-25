namespace MexicanFoodStore.UI
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int length)
        {
            if (value.Length < length) return value;
            return value.Trim().Substring(length - 4).Trim() + "...";
        }
    }
}
