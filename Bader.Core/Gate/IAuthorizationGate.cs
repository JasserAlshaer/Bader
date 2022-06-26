using System;
using Bader.Core.Data;
using Bader.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bader.Core.Gate
{
    public  interface IAuthorizationGate
    {
        public bool LogoutFromSystem(String email);

        public String LoginCredinital(LoginFillterDTO fillter);


        public Task<bool> RegisterNewCharity(CharityRegisterDTO charity, String email, string password);

        public bool ResetPassword(ResetDTO dto);

        public bool ResponseToCharityAddingRequest(int response, int charityId);
    }
}
