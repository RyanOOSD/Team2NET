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

    }
}
