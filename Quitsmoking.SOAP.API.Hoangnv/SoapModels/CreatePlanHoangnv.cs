#nullable disable
using QuitSmoking.Repositories.HoangNV.Models;
using System.Runtime.Serialization;

namespace Quitsmoking.SOAP.API.Hoangnv.SoapModels;

[DataContract(Namespace = "http://tempuri.org/")]
public partial class CreatePlanHoangnv
{
    [DataMember]
    public int CreatePlanQuitSmokingHoangNvid { get; set; }

    [DataMember]
    public int UserAccountHoangNvid { get; set; }

    [DataMember]
    public string PlanTitle { get; set; } = null!;

    [DataMember]
    public DateTime StartDate { get; set; }

    [DataMember]
    public DateTime TargetEndDate { get; set; }

    [DataMember]
    public int CurrentSmokingFrequency { get; set; }

    [DataMember]
    public int? DailyReductionGoal { get; set; }

    [DataMember]
    public string MotivationReason { get; set; } = null!;

    [DataMember]
    public string SelectedApproach { get; set; } = null!;

    [DataMember]
    public bool? IsActive { get; set; }

    [DataMember]
    public DateTime? CreationDateTime { get; set; }

    [DataMember]
    public ICollection<PlanQuitMethodHoangNv> PlanQuitMethodHoangNvs { get; set; } = new List<PlanQuitMethodHoangNv>();

    [DataMember]
    public ICollection<RecordProcessHoangNv> RecordProcessHoangNvs { get; set; } = new List<RecordProcessHoangNv>();

    [DataMember]
    public UserAccountHoangNv UserAccountHoangNv { get; set; } = null!;
}
