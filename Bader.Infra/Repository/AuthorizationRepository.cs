using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bader.Infra.Repository
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly BaderContext _context;

        public AuthorizationRepository(BaderContext context)
        {
            _context = context;
        }

        public bool InsertVeriricationCodeRecord(VerficationCode verificationCode)
        {
            _context.Add(verificationCode);
            _context.SaveChanges();
            return true;
        }

        public LoginResultDTO LoginCredinital(LoginFillterDTO fillter)
        {
            var auth = _context.Logins.Where(rec => rec.Email == fillter.Email && rec.Password == fillter.Password).FirstOrDefault();
            if (auth == null)
            {
                return null;
            }
            else
            {
                if (auth.LastLogout < auth.LastLogin) //the user still login 
                {
                    return null;
                }
                else
                {
                    auth.LastLogin = DateTime.Now;
                    _context.Update(auth);
                    _context.SaveChanges();
                    LoginResultDTO loginResultDTO = new LoginResultDTO();
                    loginResultDTO.Email = auth.Email;
                    loginResultDTO.roleID = auth.RoleId;
                    loginResultDTO.AdminId= auth.AdminId;
                    loginResultDTO.CharityID = auth.CharityId;
                    return loginResultDTO;
                  

                }


            }
        }

        public bool LogoutFromSystem(string email)
        {
            var auth = _context.Logins.Where(rec => rec.Email == email).FirstOrDefault();
            if (auth == null)
            {
                return false;
            }
            else
            {
                auth.LastLogout = DateTime.Now;
                _context.Update(auth);
                _context.SaveChanges();
                return true;


            }
        }

        public bool RegisterNewCharity(Charity charity, string email, string password)
        {


            _context.Add(charity);
            _context.SaveChanges();

            Login login = new Login();
            login.Email = email;
            login.Password=password;
            login.CharityId= _context.Charities.OrderByDescending(x => x.CharityId)
                    .FirstOrDefault().CharityId;
            login.RoleId = 2;
            _context.Add(login);
            _context.SaveChanges();

            return true;
        }

        public bool ResponseToCharityAddingRequest(int response, int charityId)
        {
            var charityInfo = _context.Charities.Where((rec) => rec.CharityId == charityId).SingleOrDefault();
            if (charityInfo != null)
            {
                if (response == 1)
                {
                    charityInfo.IsActive = true;
                    _context.Update(charityInfo);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    charityInfo.IsActive = false;
                    _context.Update(charityInfo);
                    _context.SaveChanges();
                    return true;
                }

            }
            return false;
        }

        public bool VerifiyUserEmail(VerficationCode verificationCode)
        {
            _context.Add(verificationCode);
            _context.SaveChanges();
            return true;
        }
    }
}
