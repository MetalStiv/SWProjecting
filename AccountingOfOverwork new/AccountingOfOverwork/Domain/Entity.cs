using System;

namespace AccountingOfOverwork.Domain
{
    public abstract class Entity
    {
        private Guid id;

        public Guid Id
        {
            get { return id; }
        }

        protected Entity()
        {
            id = Guid.NewGuid();
        }
    }
}
