namespace DI_Service_LifeTime.Services
{
    public class ScoopedGuidService: IScoopedGuidService
    {
        private readonly Guid Id;

        public ScoopedGuidService()
        {
            Id = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
