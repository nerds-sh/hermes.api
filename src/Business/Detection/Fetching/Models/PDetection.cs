namespace Business.Detection.Fetching.Models
{
    using System;
    using Business.Pagination.Models;

    public class PDetection
    {
        public int? Id { get; set; }

        public float? Score { get; set; }

        public string Class { get; set; }

        public PTimestamp Timestamp { get; set; } = new PTimestamp();

        public PPagination Pagination { get; set; } = new PPagination();

        public string CameraId { get; set; }
    }
}
