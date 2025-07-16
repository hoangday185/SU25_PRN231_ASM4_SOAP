using Quitsmoking.SOAP.API.Hoangnv.SoapModels;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Services.HoangNV;
using System.ServiceModel;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Quitsmoking.SOAP.API.Hoangnv.services
{
    [ServiceContract]
    public interface ICreatePlanHoangnvSOAP
    {
        [OperationContract]
        Task<List<CreatePlanQuitSmokingHoangNv>> List();

        [OperationContract]
        Task<CreatePlanQuitSmokingHoangNv?> GetById(int id);

        [OperationContract]
        Task<CreatePlanQuitSmokingHoangNv> Create(CreatePlanHoangnv plan);

        [OperationContract]
        Task<CreatePlanQuitSmokingHoangNv> Update(CreatePlanHoangnv plan);

        [OperationContract]
        Task<bool> Delete(int id);
    }
    public class CreatePlanHoangnvSOAP : ICreatePlanHoangnvSOAP
    {
        private readonly IServiceProviders _serviceProviders;

        public CreatePlanHoangnvSOAP(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        public async Task<CreatePlanQuitSmokingHoangNv> Create(CreatePlanHoangnv plan)
        {
            try
            {
                // Log toàn bộ giá trị các property của plan khi nhận vào
                Console.WriteLine("[LOG] Received plan in Create method:");
                if (plan == null)
                {
                    Console.WriteLine("[LOG] plan is null");
                }
                else
                {
                    Console.WriteLine($"[LOG] CreatePlanQuitSmokingHoangNvid: {plan.CreatePlanQuitSmokingHoangNvid}");
                    Console.WriteLine($"[LOG] UserAccountHoangNvid: {plan.UserAccountHoangNvid}");
                    Console.WriteLine($"[LOG] PlanTitle: {plan.PlanTitle}");
                    Console.WriteLine($"[LOG] StartDate: {plan.StartDate}");
                    Console.WriteLine($"[LOG] TargetEndDate: {plan.TargetEndDate}");
                    Console.WriteLine($"[LOG] CurrentSmokingFrequency: {plan.CurrentSmokingFrequency}");
                    Console.WriteLine($"[LOG] DailyReductionGoal: {plan.DailyReductionGoal}");
                    Console.WriteLine($"[LOG] MotivationReason: {plan.MotivationReason}");
                    Console.WriteLine($"[LOG] SelectedApproach: {plan.SelectedApproach}");
                    Console.WriteLine($"[LOG] IsActive: {plan.IsActive}");
                    Console.WriteLine($"[LOG] CreationDateTime: {plan.CreationDateTime}");
                    //    Console.WriteLine($"[LOG] PlanQuitMethodHoangNvs: {(plan.PlanQuitMethodHoangNvs == null ? "null" : plan.PlanQuitMethodHoangNvs.Count.ToString())}");
                    //    Console.WriteLine($"[LOG] RecordProcessHoangNvs: {(plan.RecordProcessHoangNvs == null ? "null" : plan.RecordProcessHoangNvs.Count.ToString())}");
                    //    Console.WriteLine($"[LOG] UserAccountHoangNv: {(plan.UserAccountHoangNv == null ? "null" : "not null")}");
                    //
                }

                var opt = new JsonSerializerOptions()
                { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

                opt.Converters.Add(new DateOnlyJsonConverter());

                var rsJsonString = JsonSerializer.Serialize(plan, opt);


                var rs = JsonSerializer.Deserialize<CreatePlanQuitSmokingHoangNv>(rsJsonString, opt);

                var result = await _serviceProviders.CreatePlanQuitSmokingHoangNvService.CreatePlanAsync(rs);


                return rs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[LOG][ERROR] Exception in Create: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {

                var service = _serviceProviders.CreatePlanQuitSmokingHoangNvService;

                var plan = await service.GetPlanByIdAsync(id);
                if (plan == null)
                {
                    return false; // Plan not found
                }

                return await service.DeletePlanAsync(id);
            }
            catch (Exception)
            {
                // handle log
            }
            return false;
        }

        public async Task<CreatePlanQuitSmokingHoangNv?> GetById(int id)
        {
            try
            {
                var service = _serviceProviders.CreatePlanQuitSmokingHoangNvService;

                var plan = await service.GetPlanByIdAsync(id);
                if (plan == null)
                {
                    return null; // Plan not found
                }

                return await service.GetPlanByIdAsync(id);
            }
            catch (Exception)
            {
                // handle log
            }
            return null;
        }

        public async Task<List<CreatePlanQuitSmokingHoangNv>> List()
        {
            try
            {
                var service = _serviceProviders.CreatePlanQuitSmokingHoangNvService;
                return await service.GetAllPlansAsync();
            }
            catch (Exception)
            {
                // handle log
            }
            return new List<CreatePlanQuitSmokingHoangNv>();
        }

        public async Task<CreatePlanQuitSmokingHoangNv> Update(CreatePlanHoangnv plan)
        {
            try
            {
                var service = _serviceProviders.CreatePlanQuitSmokingHoangNvService;
                var existingPlan = await service.GetPlanByIdAsync(plan.CreatePlanQuitSmokingHoangNvid);
                if (existingPlan == null)
                {
                    return new CreatePlanQuitSmokingHoangNv(); // Plan not found
                }
                var opt = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                };
                var planJson = JsonSerializer.Serialize(plan, opt);
                var updatedPlan = JsonSerializer.Deserialize<CreatePlanQuitSmokingHoangNv>(planJson, opt);
                // Map tất cả property từ updatedPlan sang existingPlan
                existingPlan.PlanTitle = updatedPlan.PlanTitle;
                existingPlan.StartDate = updatedPlan.StartDate;
                existingPlan.TargetEndDate = updatedPlan.TargetEndDate;
                existingPlan.CurrentSmokingFrequency = updatedPlan.CurrentSmokingFrequency;
                existingPlan.DailyReductionGoal = updatedPlan.DailyReductionGoal;
                existingPlan.MotivationReason = updatedPlan.MotivationReason;
                existingPlan.SelectedApproach = updatedPlan.SelectedApproach;
                existingPlan.IsActive = updatedPlan.IsActive;
                existingPlan.CreationDateTime = updatedPlan.CreationDateTime;
                await service.UpdatePlanAsync(existingPlan);
                return existingPlan;
            }
            catch (Exception)
            {
                // handle log
            }
            return new CreatePlanQuitSmokingHoangNv();
        }

        public class DateOnlyJsonConverter : JsonConverter<DateOnly>
        {
            private const string Format = "yyyy-MM-dd";
            public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (DateOnly.TryParse(value, out var date))
                {
                    return date;
                }
                throw new JsonException($"Unable to convert \"{value}\" to DateOnly.");
            }

            public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString(Format));
            }
        }
    }
}



