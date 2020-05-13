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

        public Data Give(int index)
        {
            return listOfDatas[index];
        }

        public int Size()
        {
            return listOfDatas.Count;
        }

        public void Delete(Data dataToRemove)
        {
            bool found = false;
            int i = 0;
            while(found != true)
            {
                if (listOfDatas.ElementAt(i).Equals(dataToRemove))
                {
                    listOfDatas.RemoveAt(i);
                    found = true;
                }
                i++;
            }
        }
    }
}
