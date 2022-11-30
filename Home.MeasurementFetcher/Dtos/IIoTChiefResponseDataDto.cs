namespace Home.MeasurementFetcher.Dtos
{
    internal interface IIoTChiefResponseDataDto<TEntity>
    {
        public TEntity ConvertToEntity();
    }
}
