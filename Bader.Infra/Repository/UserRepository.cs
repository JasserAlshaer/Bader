using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Bader.Infra.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly BaderContext _context;

        public UserRepository(BaderContext context)
        {
            _context = context;
        }
       

        public bool DonateToSite(DonationDTO siteDonar)
        {

            var card = _context.PaymentMethods.Where(x => x.CardNumber == siteDonar.CardNumber
              && x.Cvv2 == siteDonar.Cvv2 && x.Balance >= Convert.ToDouble(siteDonar.Amount)).SingleOrDefault();
            if (card != null)
            {
                 card.Balance -= Convert.ToDouble(siteDonar.Amount);
                _context.Update(card);
                _context.SaveChanges();
                if (Convert.ToInt32(siteDonar.DonationCampaignsId) == 0)
                {
                    SiteDonar site = new SiteDonar();
                    site.Email=siteDonar.Email;
                    site.Amount= Convert.ToDouble(siteDonar.Amount);
                    _context.Add(site);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    Donor donor=new Donor();
                    donor.DonationCampaignsId=Convert.ToInt32(siteDonar.DonationCampaignsId);
                    donor.Amount= Convert.ToDouble(siteDonar.Amount);
                    donor.Name=siteDonar.Name;
                    _context.Add(donor);
                    _context.SaveChanges();
                    return true;
                }
                
            }
            else
            {
                return false;
            }
           
        }



        public  List<DonationCampaignsResultDTO>FetchDonationCampagin(DonationCampaingeRequestDTO fillter)
        {   
            List<DonationCampaignsResultDTO> result = new List<DonationCampaignsResultDTO>();
            List<DonationCampaign> campaigns = _context.DonationCampaigns.ToList();

            foreach(DonationCampaign campaign in campaigns)
            {
                DonationCampaignsResultDTO opt=new DonationCampaignsResultDTO();
                opt.DonationCampaignsId=campaign.DonationCampaignsId;
                opt.StartAt=campaign.StartAt;
                opt.EndAt=campaign.EndAt;
                opt.TargetAmount=campaign.TargetAmount;
                opt.CharityId=campaign.CharityId;
                opt.Description=campaign.Description;
                opt.Sum=_context.Donors.Where(y => y.DonationCampaignsId == campaign.DonationCampaignsId).Sum(x => x.Amount).Value;
                result.Add(opt);
              }
              return result;
        }

        public List<Initiative> FetchInitiative(InitiativeDTO fillter)
        {
            return _context.Initiatives.Where(x=>x.EndAt<= DateTime.Now).DefaultIfEmpty().ToList();
        }

        public List<Charity> GetAllCharity()
        {
            return _context.Charities.DefaultIfEmpty().Where(x=>x.IsActive==true).ToList();
        }
        
        public CharitySingleDTO GetCharityById(int id)
        {
            CharitySingleDTO charitySingle=new CharitySingleDTO();
            Charity i= _context.Charities.Where(x=> x.CharityId==id).DefaultIfEmpty().SingleOrDefault();
            charitySingle.CharityId=i.CharityId;
            charitySingle.Description=i.Description;
            charitySingle.PreviewVideoPath=i.PreviewVideoPath;
            charitySingle.ProfileImagePath=i.ProfileImagePath;
            charitySingle.Phone=i.Phone;
            charitySingle.DateofEstablishment=i.DateofEstablishment;
            charitySingle.Name=i.Name;
            charitySingle.Addresses= _context.Addresses.Where(x=> x.CharityId==i.CharityId).ToList();
            charitySingle.Services = _context.Services.Where(x => x.CharityId == i.CharityId).ToList();
            charitySingle.Links = _context.Links.Where(x => x.CharityId == i.CharityId).ToList();
            return charitySingle;
        }
        
        public List<Charity> GetCharityByName(string name="")
        {
            return _context.Charities.Where(item => item.Name.Contains(name)).ToList();
        }

        public DonationCampaign GetDonationCampaignById(int id)
        {
            return _context.DonationCampaigns.Where(d=>d.DonationCampaignsId==id).DefaultIfEmpty().SingleOrDefault();
        }

        public double GetDonationSummaation()
        {
            return _context.SiteDonars.Sum(x => x.Amount).Value;
        }

        public Initiative GetInitiativeById(int id)
        {
            return _context.Initiatives.Where(i => i.InitiativesId == id).DefaultIfEmpty().SingleOrDefault();
        }

        public WebStaticsDTO GetAllNumericInfo()
        {
            WebStaticsDTO webStaticsDTO = new WebStaticsDTO();
            webStaticsDTO.SummationOfInitiatives = _context.Initiatives.Count();
            webStaticsDTO.SummationOfSubscriber = _context.Subscribers.Count();
            webStaticsDTO.SummationOfDonationCampainge=_context.DonationCampaigns.Count();
            //webStaticsDTO.SummationOfDonations = _context.SiteDonars.Sum(x=> x.Amount).Value;
            return webStaticsDTO;
        }

        public Survey GetSurveyById(int id)
        {
            return _context.Surveys.Where(s => s.SurveyId == id).DefaultIfEmpty().SingleOrDefault();
        }

        public bool InsertMassage(Message message)
        {
            _context.Add(message);
            _context.SaveChanges();
            return true;
        }
        public bool SubscribeTheSite(SubscriberDto subscriber)
        {
            
                Subscriber subscriber1 = new Subscriber();
                subscriber1.Email = subscriber.Email;
                subscriber1.Name = subscriber.Name;
                _context.Add(subscriber1);
                _context.SaveChanges();
                return true;
           
           
        }


        public bool InsertUserAnswerForSurvey(UserSuervy userSurveyAnswer)
        {
            _context.Add(userSurveyAnswer);
            _context.SaveChanges();
            return true;
        }

    }
}
