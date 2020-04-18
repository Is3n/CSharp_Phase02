using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace MyCartographyObjects
{
    public abstract class CartoObjs
    {
        #region VARIABLES MEMBRES
        protected static int _nextId;
        protected int _id;
        #endregion

        #region SETTER / GETTER
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public CartoObjs()
        {
            this.Id = Interlocked.Increment(ref _nextId);
        }
        #endregion

        #region METHODES

        public override string ToString()
        {
            return Id.ToString();
        }

        public abstract void Draw();

        #endregion
    }
}
