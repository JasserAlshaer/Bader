using Bader.Core.Data;
using Bader.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bader.Core.Repository
{
    public  interface IAuthorizationRepository
    {
        public bool LogoutFromSystem(String email);

        public LoginResultDTO LoginCredinital(LoginFillterDTO fillter);

        public bool VerifiyUserEmail(VerficationCode verificationCode);

        public bool InsertVeriricationCodeRecord(VerficationCode verificationCode);


        public Task<bool> RegisterNewCharity(Charity charity, String email, string password);

      

        public bool ResponseToCharityAddingRequest(int response, int charityId);



        public bool ResetPassword(ResetDTO dto);
    }
}
