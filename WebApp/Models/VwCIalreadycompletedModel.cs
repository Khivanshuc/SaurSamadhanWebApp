using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("CommunityIrrigationAlreadyCompleted/admin")]
    public class VwCIalreadycompletedModel : IModel
    {
        public long Id { get; set; }
        public string User { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string Site { get; set; }
        public string Project { get; set; }
        public DateTime InspectionDate { get; set; }
        public string GramPanchayat { get; set; }
        public string WaterSourceName { get; set; }
        public string ProjectArea { get; set; }
        public long FarmerCount { get; set; }
        public int SolarPumpCapacityinHP { get; set; }
        public int SolarPumpCount { get; set; }
        public bool PumpStatus { get; set; }
        public float WorkingPumpCount { get; set; }
        public float NonWorkingPumpCount { get; set; }
        public bool ControllerStatus { get; set; }
        public float WorkingControllerCount { get; set; }
        public float NonWorkingControllerCount { get; set; }
        public string SolarModule { get; set; }
        public string LightningArresterStatus { get; set; }
        public string PipelineLength { get; set; }
        public string PipeLineStatusRemark { get; set; }
        public int SafetyFencingLength { get; set; }
        public string FencingAndGateStatusRemark { get; set; }
        public string ControlRoomRemark { get; set; }
        public bool IsSystemWorking { get; set; }
        public string OtherRemark { get; set; }
        public string GeoTag { get; set; }
        public string SolarPumpImage { get; set; }
        public string SolarPumpImageType { get; set; }
        public string ControlRoomImage { get; set; }
        public string ControlRoomImageType { get; set; }
        public string SolarPanelImage { get; set; }
        public string SolarPanelImageType { get; set; }
        public string FencingImage { get; set; }
        public string FencingImageType { get; set; }
        public string PipeOutletImage { get; set; }
        public string PipeOutletImageType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }
        public string Status { get; set; }
        public DateTime AssignedDate { get; set; }
        public long AssignedTo { get; set; }
        public long SIId { get; set; }

    }
}
