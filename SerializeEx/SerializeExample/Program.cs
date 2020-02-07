namespace SerializeExample
{
    using System;
    using System.Collections.Generic;
    using SerializeXML;

    class Program
    {
        static void Main()
        {
            List<UserInfo> infos = new List<UserInfo>();
            infos.Add(new UserInfo() { UserName = "John", UserLocation = "US", UserBirth = new DateTime(2000, 01, 01) });
            infos.Add(new UserInfo() { UserName = "ゆり", UserLocation = "JP", UserBirth = new DateTime(2001, 02, 02) });
            infos.Add(new UserInfo() { UserName = "철수", UserLocation = "KR", UserBirth = new DateTime(2002, 03, 03) });

            SerializeEx.Serialization(infos, Environment.CurrentDirectory + "\\infos");
            var loadInfos = SerializeEx.DeSerialization<List<UserInfo>>(Environment.CurrentDirectory + "\\infos");
            foreach (var i in loadInfos)
            {
                string outputResult = "Name : " + i.UserName + "  Location : " + i.UserLocation + " Birth : " + i.UserBirth;
                Console.WriteLine(outputResult);
            }
        }
    }

    public class UserInfo
    {
        public string UserName;
        public string UserLocation;
        public DateTime UserBirth;
    }
}