using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class AgenciesDB
    {
        

        public static Agency GetAgency(string agencyCity)
        {
            Agency? agency = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                agency = db.Agencies.Where(a => a.AgncyCity == agencyCity).FirstOrDefault();

            }
            return agency;
        }

        public static string LoadProvince()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                string province = db.Agencies.Select(a => a.AgncyProv).FirstOrDefault();
                return province;
            }
        }

        public static void AddAgency(Agency selectedAgency)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
               
                db.Agencies.Add(selectedAgency);
                db.SaveChanges();
            }
        }

        public static void ModifyAgency(int agencyId, Agency selectedAgency)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Agency modifiedAgency = db.Agencies.Find(agencyId);
                if (modifiedAgency != null)
                {
                    modifiedAgency.AgncyAddress = selectedAgency.AgncyAddress;
                    modifiedAgency.AgncyCity = selectedAgency.AgncyCity;
                    modifiedAgency.AgncyProv = selectedAgency.AgncyProv;
                    modifiedAgency.AgncyPostal = selectedAgency.AgncyPostal;
                    modifiedAgency.AgncyPhone = selectedAgency.AgncyPhone;
                    modifiedAgency.AgncyFax = selectedAgency.AgncyFax;
                    
                }
                db.SaveChanges();
            }
        }

        public static void DeleteAgency(int agencyId)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Agency agencyToDelete = db.Agencies.Find(agencyId);
                if (agencyToDelete != null)
                {
                    db.Agencies.Remove(agencyToDelete);
                    db.SaveChanges();
                }
            }
        }
    }


}
