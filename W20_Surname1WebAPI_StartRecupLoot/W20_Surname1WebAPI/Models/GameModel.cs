using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W22_CorcolesWebAPI.Models
{
    public class GameModel
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _idplayer;
        public string IdPlayer
        {
            get { return _idplayer; }
            set { _idplayer = value; }
        }

        private int _remainingloot;
        public int RemainingLoot
        {
            get { return _remainingloot; }
            set { _remainingloot = value; }
        }

        private string _toploots;
        public string TopLoots
        {
            get { return _toploots; }
            set { _toploots = value; }
        }

        private string _lastloots;
        public string LastLoots
        {
            get { return _lastloots; }
            set { _lastloots = value; }
        }
    }
}