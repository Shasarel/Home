namespace Home.WebApi.Extensions
{
    public static class IDictionaryExtensions
    {
        public static List<double?> SelectMax<T>(this Dictionary<DateTimeOffset, List<T>> groups, Func<T, double> func) =>
            groups.SelectWithFunc(x => x.Value.Max(func));

        public static List<double?> SelectMin<T>(this Dictionary<DateTimeOffset, List<T>> groups, Func<T, double> func) =>
             groups.SelectWithFunc(x => x.Value.Min(func));

        public static List<double?> SelectAvg<T>(this Dictionary<DateTimeOffset, List<T>> groups, Func<T, double> func) =>
            groups.SelectWithFunc(x => Math.Round(x.Value.Average(func), 2));

        public static List<double?> SelectDifference<T>(this Dictionary<DateTimeOffset, List<T>> groups, Func<T, double> diffFunc, Func<T, double> sumFunc) =>
            groups.SelectWithFunc(x => Math.Round(diffFunc(x.Value.Last()) - diffFunc(x.Value.First()) + sumFunc(x.Value.First()), 2));

        public static List<double?> SelectWithFunc<T>(this Dictionary<DateTimeOffset, List<T>> groups, Func<KeyValuePair<DateTimeOffset, List<T>>, double?> func) => 
            groups.Select(x =>
            {
                if (!x.Value.Any())
                    return null;

                return func(x);

            }).ToList();
    }
}
