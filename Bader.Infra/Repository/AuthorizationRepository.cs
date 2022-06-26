using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bader.Infra.Repository
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly BaderContext _context;

        public AuthorizationRepository(BaderContext context)
        {
            _context = context;
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
                return sBuilder.ToString();
        }

        static string EncryptData(string text)
        {
            string encText = "";
            char[] chars = text.ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                
                int temp = (int)chars[i] + (int)new Random().Next(9);
                chars[i] = (char)temp;
            }

            foreach (char c in chars)
            {
                encText += c;
            }

            return encText;
        }


        public bool InsertVeriricationCodeRecord(VerficationCode verificationCode)
        {
            _context.Add(verificationCode);
            _context.SaveChanges();

            return true;
        }

        public LoginResultDTO LoginCredinital(LoginFillterDTO fillter)
        {
            //encryption
            using (MD5 md5Hash = MD5.Create())
            {
                fillter.Email = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, fillter.Email))));
                fillter.Password = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, fillter.Password))));
            }
            var auth = _context.Logins.Where(rec => rec.Email.Substring(0,32) == fillter.Email && rec.Password.Substring(0,32) == fillter.Password).FirstOrDefault();
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

        public async Task<bool> RegisterNewCharity(Charity charity, string email, string password)
        {

            using (MD5 md5Hash = MD5.Create())
            {
                email = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, email))))+ EncryptData("-Bader") + GetMd5Hash(md5Hash, DateTime.Now.ToString());
                password = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, password)))) +EncryptData("-Bader") + GetMd5Hash(md5Hash, DateTime.Now.ToString());
            }

            

            
            _context.Add(charity);
            await _context.SaveChangesAsync();

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

        public bool ResetPassword(ResetDTO dto)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                dto.Email = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, dto.Email))));
                dto.Password = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, dto.Password))));
            }
            var login = _context.Logins.Where(rec => rec.Email.Substring(0, 32) == dto.Email).FirstOrDefault();
            if (login != null)
            {
                 login.Email = dto.Email;
                 login.Password = dto.Password;
                _context.Update(login);
                _context.SaveChanges();
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
