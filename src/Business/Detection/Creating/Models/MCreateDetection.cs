namespace Business.Detection.Creating.Models
{
    using System;

    public class MCreateDetection
    {
        public float Score { get; set; }

        public string Class { get; set; }

        public DateTime Timestamp { get; set; }

        public string CameraId { get; set; }
    }
}
