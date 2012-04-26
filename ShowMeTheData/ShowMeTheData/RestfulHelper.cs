using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml;
using System.Threading;

namespace ShowMeTheData
{
    class RestfulHelper
    {
        private const int TEAMS = 35;

        private const int PLAYER_COUNT = 300;
        struct NBATeam
        {
            public string name;
            public int wins;
            public int losses;
            public float gamesBack;
            public float winPercentage;
        };
        struct NBAPlayer
        {
            public string teamName;
            public string name;
            public string birthData;
            public int weight;
            public int height;
            public int number;
        }


        #region Variables

        private static HttpWebRequest request;
        private static HttpWebResponse response;
        private static Stream responseStream;
        private static StreamReader streamReader;

        //uri key broken down into parts
        private static string uri = "http://api.sportsdatallc.org/nba-t1/standings?season_id=2011&api_key=54exz7sw2tqszdffjxcqy5gx";
        private const string uriBegining = "http://api.sportsdatallc.org/";
        private const string uriKey_NBA = "&api_key=xxpz8nh8my5actcs5hj7t4xn";
        private const string uriKey_NFL = "&api_key=6sxg8v3dgmzfrtfxy2x5javt";
        private const string uriKey_MLB = "&api_key=m5mrmzx5xzgeu64a3qxkrusz";
        private const string uriKey_NHL = "&api_key=ckg4xxvksk9fyh7utwpjgtwk";
        private string[] uriKeys;
        private static int currentURI = 0;
        private static string uriSport = "nba-t1/";
        private static string uriData = "standings?";
        private static string uriSeason = "season_id=2011";

        private static string teamName;
        private static NBATeam[] teams;
        private static NBAPlayer[] players;
        private static int teamCount = 0;
        #endregion

        #region Getters/Setters/Constructor
        public RestfulHelper()
        {
            teams= new NBATeam[TEAMS];
            players = new NBAPlayer[PLAYER_COUNT];
            teamCount = 0;
            uriKeys = new string[4];
            uriKeys[0] = uriKey_NBA;
            uriKeys[1] = uriKey_NFL;
            uriKeys[2] = uriKey_NHL;
            uriKeys[3] = uriKey_MLB;
        }

        public void SetURI()
        {
            uri = uriBegining + uriSport + uriData + uriSeason + uriKeys[currentURI];
        }

        public void SetTeam(string name)
        {
            teamName = name;
        }

        public void SetSport(string sport)
        {
            uriSport = sport.ToLower() + "-t1/";
            switch (sport)
            {
                case "NBA":
                    currentURI = 0;
                    break;
                case "NFL":
                    currentURI = 1;
                    break;
                case "NHL":
                    currentURI = 2;
                    break;
                case "MLB":
                    currentURI = 3;
                    break;

            }
            SetURI();
        }

        public void SetSeason(string season)
        {
            uriSeason = "season_id=" + season.ToLower();
            SetURI();
        }

        public void SetData(string data)
        {
            uriData = data.ToLower() + "?";
            SetURI();
        }

        #endregion

        public void RequestData()
        {
                                                        //http://api.sportsdatallc.org/nhl-t1/standings?season_id=2011&api_key=nwdb5xn7aqasbms9axakbwjx
            request = (HttpWebRequest)WebRequest.Create(uri);
            response = (HttpWebResponse)request.GetResponse();
            responseStream = response.GetResponseStream();
            streamReader = new StreamReader(responseStream);

            if(currentURI == 0)                     //if its NBA
            {
                if(uriData == "standings?")
                    ParseDataNBA_Standings();
                else
                    ParseDataNBA_Stats();

            }
            if (currentURI == 2)
            {
                if (uriData == "standings?")
                    ParseDataNBA_Standings();
                else
                    ParseDataNBA_Stats();
            }
             
        }

        public void ParseDataNBA_Standings()
        {
            StringBuilder output = new StringBuilder();

            string xmlString = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            response.Close();

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                while (reader.Read())
                {
                    if (reader.ReadToFollowing("Standing"))
                    {
                        while(reader.Name != "name")
                            reader.MoveToNextAttribute();

                        //assign the name
                        teams[teamCount] = new NBATeam();
                        teams[teamCount].name = reader.Value;

                        reader.ReadToFollowing("Won");
                        teams[teamCount].wins = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("Lost");
                        teams[teamCount].losses = reader.ReadElementContentAsInt();

                        
                        reader.ReadToFollowing("PCT");
                        teams[teamCount].winPercentage = reader.ReadElementContentAsFloat();

                        reader.ReadToFollowing("GB");
                        teams[teamCount].gamesBack = reader.ReadElementContentAsFloat();

                        teamCount++;
                    }
                }
            }
        }

        public void ParseDataNBA_Stats()
        {
            StringBuilder output = new StringBuilder();

            string xmlString = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            response.Close();
            int playerCount = 0;
            bool onceOver = false;
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                while (reader.Read())
                {
                    if (onceOver)
                        continue;
                    string temp = "";
                    while (temp != teamName)
                    {
                        reader.ReadToFollowing("Team");
                        reader.ReadToFollowing("name");
                        temp = reader.ReadElementContentAsString();
                    }
                    
                    onceOver = true;
                    for(int i =0; i < 20; i++)
                    {
                        players[playerCount] = new NBAPlayer();
                        reader.ReadToFollowing("Player");
                        reader.ReadToFollowing("Name");
                        players[playerCount].teamName = temp;
                        players[playerCount].name = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("Stat");
                        reader.ReadToFollowing("Stat");
                        reader.ReadToFollowing("Stat");
                        reader.MoveToAttribute("birth_date");
                        players[playerCount].birthData = reader.ReadElementContentAsString();
                        
                        reader.ReadToFollowing("Stat");
                        players[playerCount].weight = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("Stat");
                        reader.ReadToFollowing("Stat");
                        players[playerCount].height = reader.ReadElementContentAsInt();

                        reader.ReadToFollowing("Stat");
                        players[playerCount].number = reader.ReadElementContentAsInt();

                        playerCount++;
                        
                    
                    }                    
                }
            }
        }


        public string GetData()
        {
            string s = "";

            if (uriSport == "nba-t1/")
            {
                if (uriData == "standings?")
                {
                    s = GetNBAStandings();
                }
                else
                {
                    s = GetNBATeam();
                }
            }
            else if (uriSport == "nhl-t1/")
            {
                if (uriData == "standings?")
                {
                    s = GetNBAStandings();
                }
                else
                {
                    s = GetNBATeam();
                }
            }


            return s;
        }

        private string GetNBATeam()
        {
            string data = "Team: " + players[0].teamName;
            data += "@@Player Name\t\tBirth Day\t\tHeight\tWeight\tNumber@";

            for (int i = 0; i < 20; i++)
            {
                if(players[i].name.Length >= 20)
                    data += players[i].name + "\t" + players[i].birthData + "\t" + players[i].height + "\t" + players[i].weight + "\t" + players[i].number + "@";
                else
                    data += players[i].name + "\t\t" + players[i].birthData + "\t" + players[i].height + "\t" + players[i].weight + "\t" + players[i].number + "@";
            }

            data = data.Replace("@", System.Environment.NewLine);


            return data;
        }

        private string GetNBAStandings()
        {
            string data = "Team Name\t\tWins\tLosses\tPercentage\tGB@";

            for (int i = 0; i < teamCount; i++)
            {
                if (teams[i].name.Length >= 20 || teams[i].name.Length == 18 && teams[i].name != "Philadelphia 76ers")
                    data += teams[i].name + "\t" + teams[i].wins + "\t" + teams[i].losses + "\t" + teams[i].winPercentage + "\t\t" + teams[i].gamesBack + "@";
                else
                    data += teams[i].name + "\t\t" + teams[i].wins + "\t" + teams[i].losses + "\t" + teams[i].winPercentage + "\t\t" + teams[i].gamesBack + "@";
            }

            data = data.Replace("@", System.Environment.NewLine);


            return data;
        }
    }
}
