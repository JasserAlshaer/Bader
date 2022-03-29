using System;
using Bader.Core.Data;
using Bader.Core.DTO;
using System.Collections.Generic;

namespace Bader.Core.Gate
{
    public  interface IAuthorizationGate
    {
        public bool LogoutFromSystem(String email);

        public LoginResultDTO LoginCredinital(LoginFillterDTO fillter);

        public bool VerifiyUserEmail(VerficationCode verificationCode);

        public bool InsertVeriricationCodeRecord(VerficationCode verificationCode);


        public bool RegisterNewCharity(Charity charity, String email, string password);

        public bool InsertNewSubscriberRecord(Subscriber subscriber);

        public bool ResponseToCharityAddingRequest(int response, int charityId);
    }
}
