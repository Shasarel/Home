namespace Home.WebApi.Extensions
{
    public static class IGroupingExtensions
    {
        public static Dictionary<DateTimeOffset, List<T>> AddMissingGroups<T>(this IEnumerable<IGrouping<int, T>> groups, Func<KeyValuePair<int, List<T>>, DateTimeOffset> groupIdToDateFunc, int groupCount) where T : new()
        {
            var groupsDictionary = groups.ToDictionary(g => g.Key, g => g.ToList());

            for (int i = 0; i < groupCount; i++)
            {
                if (!groupsDictionary.ContainsKey(i))
                    groupsDictionary.Add(i, new List<T> ());
            }

            return groupsDictionary.OrderBy(x => x.Key).ToDictionary(groupIdToDateFunc, x => x.Value);
        }
    }
}
