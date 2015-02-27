using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfOverwork
{
    public class Entity
    {
        protected int id;

        public static bool operator ==(Entity a, Entity b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.id == b.id;
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public int getId()
        {
            return id;
        }

        public void setId(int _id)
        {
            id = _id;
        }

    }
}
