using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btap_4_4.DAO
{
    public class deleteStringFromIndex
    {
        private static deleteStringFromIndex instance;

        public static deleteStringFromIndex Instance {
            get
            {
                if (instance == null)
                {
                    instance = new deleteStringFromIndex();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public String delete3charLastInDateTime(String s)
        {
            s = s.Remove(s.Length - 3);
            return s;
        }
    }
}
