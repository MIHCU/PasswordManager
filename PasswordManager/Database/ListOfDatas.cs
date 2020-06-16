using PasswordManager.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PasswordManager.Database
{
    public class ListOfDatas
    {
        List<Data> listOfDatas;
        string XML;
        MyRSA rsa;

        public ListOfDatas()
        {
            rsa = new MyRSA();
            XML = "Passwords.xml";
            if (File.Exists(XML))
            {
                listOfDatas = Deserialize();
            }
            else
            {
                listOfDatas = new List<Data>();
            }
        }

        public void Add(Data dataToAdd)
        {
            Data temp = new Data(rsa.Encryption(dataToAdd.Login), rsa.Encryption(dataToAdd.Password), 
                rsa.Encryption(dataToAdd.Tag), rsa.Encryption(dataToAdd.Notes));
            listOfDatas.Add(temp);
            Serilize();
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
            Serilize();
        }

        public void Serilize()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Data>));

            using (Stream fstream = new FileStream(XML, FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fstream, listOfDatas);
            }
        }

        public List<Data> Deserialize()
        {
            FileStream stream = new FileStream(XML, FileMode.Open);
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Data>));
            return (List<Data>)xmlFormat.Deserialize(stream);
        }
    }
}
