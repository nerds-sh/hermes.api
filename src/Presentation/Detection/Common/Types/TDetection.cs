namespace Presentation.Detection.Common.Types
{
    using System.Diagnostics.CodeAnalysis;
    using Business.Detection.Common.Models;
    using global::GraphQL.Types;
    using Presentation.Camera.Common.Types;
    using Style;

    [SuppressMessage(Category.Default, Check.CA1724, Justification = Reason.Readability)]
    public sealed class TDetection : ObjectGraphType<MDetection>
    {
        public TDetection()
        {
            Field(detection => detection.Id).Description("This is the ID");
            Field(detection => detection.Score).Description("This is the Score");
            Field(detection => detection.Timestamp).Description("This is the Timestamp");
            Field(detection => detection.Class).Description("This is the Class");
            Field(detection => detection.Camera, false, typeof(TCamera)).Description("This is the camera that took the detections");
        }
    }
}
