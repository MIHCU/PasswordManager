using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    class ListOfDatas
    {
        List<Data> listOfDatas;

        public ListOfDatas()
        {
            listOfDatas = new List<Data>();
        }

        public void Add(Data data)
        {
            listOfDatas.Add(data);
        }
    }
}
