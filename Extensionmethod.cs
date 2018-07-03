        
    internal static class extensions
    {
        private static readonly List<string> allowedDataFields = new List<string> { "A1", "A2", "A3", "A41", "A42", "A43" };

        // .Where
        // .blabla
        //extension method for i queryable (linq queries)
        public static IQueryable<YearlyQuarterResDatas> blabla(this IQueryable<ResData> input)
        {
            return input.GroupBy(rd => rd.PortLoCode)
                .Where(rd => rd.Count() == 3)
                .SelectMany(x => x)
                .SelectMany(x => x.DataEntities.Where(rde => rde.Direction == Direction.Total && allowedDataFields.Contains(rde.ResDataField.Code))
                    .Select(rde => new YearlyQuarterResDatas
                    {
                        Locode = x.PortLoCode,
                        Year = x.Year,
                        Quarter = x.Quarter,
                        ResDataFieldCode = rde.ResDataField.Code,
                        Value = rde.Value
                    }));
        }

//normal extension method
        public static int getNummerke(this string input, int x)
        {
            return int.TryParse(input, out var result) ? result : 0;
        }
    }