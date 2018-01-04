namespace Task_02
{
    public static class IsStringPosNumber
    {
        public static bool IsPosNum(this string str)
        {
            foreach (var ch in str)
            {
                if (!char.IsNumber(ch))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
