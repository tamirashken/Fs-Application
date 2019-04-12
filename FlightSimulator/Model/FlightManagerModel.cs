using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    //should be singletone
    public class FlightManagerModel
    {
        #region Singleton
        private FlightManagerModel() { }
        private static FlightManagerModel m_Instance = null;
        public static FlightManagerModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new FlightManagerModel();
                }
                return m_Instance;
            }
        }
        #endregion
    }
}
