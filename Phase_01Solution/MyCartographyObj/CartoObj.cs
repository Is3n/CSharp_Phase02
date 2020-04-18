using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace MyCartographyObj
{
    [Serializable]
    public abstract class CartoObjs: IComparable<CartoObjs>
    {
        #region VARIABLES MEMBRES
        protected static int _nextId;
        protected int _id;
        protected int _nbCoord=0;
        #endregion

        #region SETTER / GETTER
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int NbCoord
        {
            get { return _nbCoord; }
            set { _nbCoord = value; }
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
            return "Id : " + Id.ToString();
        }

        public abstract void Draw();

        public int CompareTo(CartoObjs other)
        {
            return this.NbCoord.CompareTo(other.NbCoord);
        }

        #endregion
    }
}
