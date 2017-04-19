namespace DBGatekeeper.BusinessLogicServices
{
    public interface IChecksumService 
    {
        string GenerateChecksum(string sqlString);
        string GenerateChecksum(object obj);
    }
}
