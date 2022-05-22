using Bader.Core.Data;
using Bader.Core.DTO;
using Bader.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bader.Infra.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly BaderContext _context;

        public UserRepository(BaderContext context)
        {
            _context = context;
        }
        public bool DonateForSpecificDonationCampaign(Donor donor)
        {
            _context.Add(donor);
            _context.SaveChanges();
            return true;
        }

        public bool DonateToSite(DonationDTO siteDonar)
        {
            var card = _context.PaymentMethods.Where(x => x.CardNumber == siteDonar.CardNumber
              && x.Cvv2 == siteDonar.Cvv2 && x.Balance >= siteDonar.Amount && x.ExpireDate >= siteDonar.ExpireDate).SingleOrDefault();
            if (card != null)
            {
                if (siteDonar.DonationCampaignsId == 0 || siteDonar.DonationCampaignsId == null)
                {
                    SiteDonar site = new SiteDonar();
                    site.Email=siteDonar.Email;
                    site.Amount=siteDonar.Amount;
                    _context.Add(siteDonar);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    Donor donor=new Donor();
                    donor.DonationCampaignsId=siteDonar.DonationCampaignsId;
                    donor.Amount=siteDonar.Amount;
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



        public List<DonationCampaign> FetchDonationCampagin(DonationCampaingeRequestDTO fillter)
        {
            return _context.DonationCampaigns.DefaultIfEmpty().ToList();
        }

        public List<Initiative> FetchInitiative(InitiativeDTO fillter)
        {
            return _context.Initiatives.DefaultIfEmpty().ToList();
        }

        public List<Charity> GetAllCharity()
        {
            return _context.Charities.DefaultIfEmpty().ToList();
        }

        public Charity GetCharityById(int id)
        {
            return _context.Charities.Where(x=> x.CharityId==id).DefaultIfEmpty().SingleOrDefault();
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
            webStaticsDTO.SummationOfDonations = 0;
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
            var code=_context.VerficatioCodes.Where(s => s.Code == subscriber.Code && s.Email==subscriber.Email).SingleOrDefault();
            if(code == null)
            {
                return false;
            }
            else
            {
                Subscriber subscriber1 = new Subscriber();
                subscriber1.Email = subscriber.Email;
                subscriber1.Name = subscriber.Name;
                _context.Add(subscriber1);
                _context.SaveChanges();
                return true;
            }
           
        }

    }
}
