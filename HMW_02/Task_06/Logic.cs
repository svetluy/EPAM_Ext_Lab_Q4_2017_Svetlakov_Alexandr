namespace Task_06
{
    using System.Collections.Generic;

    public static class Logic
    {
        public static void IsInList(int counter, string parametr, List<string> param)
        {
            bool isIt;

            if (counter % 2 == 0)
            {
                isIt = false;
            }
            else
            {
                isIt = true;
            }

            CheckParams(parametr, param, isIt);
        }

        public static void CheckParams(string parametr, List<string> param, bool isIt)
        {
            if (isIt)
            {
                param.Add(parametr);
            }
            else
            {
                param.Remove(parametr);
            }
        }
    }
}
