using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Infra.Repository
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly AnsamContext _context;

        public AuthorizationRepository(AnsamContext context)
        {
            _context = context;
        }

        public bool InsertVeriricationCodeRecord(VerficationCode verificationCode)
        {
            throw new NotImplementedException();
        }

        public LoginResultDTO LoginCredinital(LoginFillterDTO fillter)
        {
            throw new NotImplementedException();
        }

        public bool LogoutFromSystem(string email)
        {
            throw new NotImplementedException();
        }

        public bool RegisterNewCharity(Charity charity, string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool ResponseToCharityAddingRequest(int response, int charityId)
        {
            throw new NotImplementedException();
        }

        public bool VerifiyUserEmail(VerficationCode verificationCode)
        {
            throw new NotImplementedException();
        }
    }
}
