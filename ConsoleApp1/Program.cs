using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User> {
                new User{Id=0, Name="Mary", Age=23},
                new User{Id=1, Name="Tom", Age=12},
                new User{Id=2, Name="Ann", Age=28}
            };
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            using (FileStream fs = File.Create("Test.xml"))
            {
                serializer.Serialize(fs, users);
            }

            List<User> clonedUsers = null;
            using (FileStream fs = File.OpenRead("Test.Xml"))
            {
                clonedUsers = (List<User>)serializer.Deserialize(fs);
            }
            foreach (User u in clonedUsers)
            {
                Console.WriteLine(u);
            }
            Console.WriteLine("Completed!");
            Console.ReadLine();
        }

        [DataContract]
        class User
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Age { get; set; }
            public override string ToString()
            {
                return string.Format("{0}, {1}, {2}", Id, Name, Age);
            }
        }
    }
}
