namespace Data.Camera
{
    using System.Linq;
    using Business.Camera.Common.Models;
    using Business.Camera.Register.Models;
    using Business.Pagination.Models;

    public static class CameraFactory
    {
        public static MCamera MakeModel(ECamera entity) => new ()
        {
            Id = entity?.Id ?? string.Empty,
            Latitude = entity?.Latitude ?? default,
            Longitude = entity?.Longitude ?? default,
        };

        public static ECamera MakeEntity(MRegisterCamera model) => new ECamera()
        {
            Id = model.Id,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
        };

        public static MPagination<MCamera> MakePaginationModel(MPagination<ECamera> pagination) => new ()
        {
            Items = pagination.Items.Select(MakeModel),
            PageIndex = pagination.PageIndex,
            PageSize = pagination.PageSize,
            TotalCount = pagination.TotalCount,
        };
    }
}
