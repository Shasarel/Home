namespace Home.WebApi.Extensions
{
    public static class IDictionaryExtensions
    {
        public static List<double?> SelectMax<T>(this Dictionary<DateTimeOffset, List<T>> groups, Func<T,double> func)
        {
            return groups.Select(x =>
            {
                if (!x.Value.Any())
                    return null;

                return (double?) x.Value.Max(func);
               
            }).ToList();
        }

        public static List<double?> SelectDifference<T>(this Dictionary<DateTimeOffset, List<T>> groups, Func<T, double> diffFunc, Func<T, double> sumFunc)
        {
            return groups.Select(x =>
            {
                if (!x.Value.Any())
                    return null;

                return (double?)Math.Round(diffFunc(x.Value.Last()) - diffFunc(x.Value.First()) + sumFunc(x.Value.First()), 2);

            }).ToList();
        }
    }
}
