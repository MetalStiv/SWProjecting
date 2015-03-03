using System;

namespace AccountingOfOverwork.Domain
{
    public class Project : Entity
    {
        private string name;

        public Project(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
