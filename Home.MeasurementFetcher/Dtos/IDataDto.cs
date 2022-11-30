namespace Home.MeasurementFetcher.Dtos
{
    internal interface IDataDto<TEntity>
    {
        public TEntity ConvertToEntity();
    }
}
