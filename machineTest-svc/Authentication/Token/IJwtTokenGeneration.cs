using machineTest_svc.Models;

namespace machineTest_svc.Authentication.Token
{
    public interface IJwtTokenGeneration
    {
        public string GenerateJwtToken(User user);
    }
}
