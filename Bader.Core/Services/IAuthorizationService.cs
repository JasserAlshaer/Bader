using System;
using Bader.Core.Data;
using Bader.Core.DTO;
using System.Collections.Generic;

namespace Bader.Core.Services
{
    public interface IAuthorizationService
    {
        public bool LogoutFromSystem(String email);

        public String LoginCredinital(LoginFillterDTO fillter);


        public bool RegisterNewCharity(Charity charity, String email, string password);

       

        public bool ResponseToCharityAddingRequest(int response, int charityId);
    }
}
