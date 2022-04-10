namespace SodaCompany.Application.Services.Interfaces
{
    public interface IHashingService
    {
        public string ComputeHash(string rawData);
        public bool CompareHash(string hash, string comparedHash);
    }
}
