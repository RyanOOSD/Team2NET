using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class AgentsDB
    {
        public static Agent GetAgent(int agentId)
        {
            Agent? agent = null;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                agent = db.Agents.Find(agentId);

            }
            return agent;
        }

        public static List<Agency> GetCity()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                return db.Agencies.OrderBy(c => c.AgncyCity).ToList();
            }
        }

        public static void AddAgent(Agent selectedAgent, string city)
        {


            using (TravelExpertsContext db = new TravelExpertsContext())
            {


                selectedAgent.AgencyId = db.Agencies.Where(a => a.AgncyCity == city).Select(a => a.AgencyId).FirstOrDefault();

                db.Agents.Add(selectedAgent);
                db.SaveChanges();
            }

        }

        public static void DeleteAgent(int agentId)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Agent agentToDelete = db.Agents.Find(agentId);
                if (agentToDelete != null)
                {
                    db.Agents.Remove(agentToDelete);
                    db.SaveChanges();
                }
            }                    

        }

        public static void ModifyAgent(int agentId, Agent selectedAgent)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Agent modifiedAgent = db.Agents.Find(agentId);
                if (modifiedAgent != null)
                {
                    modifiedAgent.AgtFirstName = selectedAgent.AgtFirstName;
                    modifiedAgent.AgtLastName = selectedAgent.AgtLastName;
                    modifiedAgent.AgtMiddleInitial = selectedAgent.AgtMiddleInitial;
                    modifiedAgent.AgtBusPhone = selectedAgent.AgtBusPhone;
                    modifiedAgent.AgtEmail = selectedAgent.AgtEmail;
                    modifiedAgent.AgtPosition = selectedAgent.AgtPosition;
                    modifiedAgent.AgencyId = selectedAgent.AgencyId;
                }
                db.SaveChanges();
            }
        }
    }
}
