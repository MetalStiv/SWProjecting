using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    public class Project : Entity
    {
        private String name;
        private String platform;
        private DateTime startTime;

        public Project()
        {
            name = "";
            platform = "";
            startTime = new DateTime(2000, 1, 1);
        }

        public Project(int _id, String _name, String _platform, DateTime _startTime)
        {
            id = _id;
            name = _name;
            platform = _platform;
            startTime = _startTime;
        }

        public String getName()
        {
            return name;
        }
        public String getPlatform()
        {
            return platform;
        }
        public DateTime getStartTime()
        {
            return startTime;
        }

        public void setName(String _name)
        {
            name = _name;
        }
        public void setPlatform(String _platform)
        {
            platform = _platform;
        }
        public void setStartTime(DateTime _startTime)
        {
            startTime = _startTime;
        }
    }
}
