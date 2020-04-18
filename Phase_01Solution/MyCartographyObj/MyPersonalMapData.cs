using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObj
{
    [Serializable]
    public class MyPersonalMapData
    {
        #region VARIABLES MEMBRES
        private string _nom;
        private string _prenom;
        private string _email;
        private ObservableCollection<ICartoObj> _maCollection;
        #endregion

        #region SETTER / GETTER
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public ObservableCollection<ICartoObj> MaCollection
        {
            get { return _maCollection; }
        }
        //public List<ICartoObj> ListeICartoObj { get; } = new List<ICartoObj>();
        #endregion

        #region CONSTRUCTEURS
        public MyPersonalMapData()
        {
            this.Nom = "Claes";
            this.Prenom = "Isen";
            this.Email = "EmailParDefaut@Isen.be";
            this._maCollection = new ObservableCollection<ICartoObj>();
        }
        public MyPersonalMapData(string nom, string prenom, string email)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
            this._maCollection = new ObservableCollection<ICartoObj>();
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return base.ToString() + " // Nom : " + Nom + " // Prenom : " + Prenom + " // Email : " + Email;
        }
        public void Draw()
        {
            Console.WriteLine(ToString());
            foreach (CartoObjs Obj in _maCollection)
            {
                Console.WriteLine(Obj.ToString());
            }
            Console.WriteLine();
        }
        public void AfficherCollection()
        {
            foreach(CartoObjs item in MaCollection)
            {
                item.Draw();
            }
        }
        public void AddCollection(ICartoObj ObCollParam)
        {
            MaCollection.Add(ObCollParam);
        }
        public void ReinitialiserCollection()
        {
            MaCollection.Clear();
        }
        public void SaveAsBinaryFormat(string filename)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using(Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                    binFormat.Serialize(fStream, MaCollection);
            }
        }
        public void LoadFromBinaryFormat(string filename)
        {
            try
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using(Stream fStream = File.OpenRead(filename))
                {
                    this._maCollection = binFormat.Deserialize(fStream) as ObservableCollection<ICartoObj>;
                }
            }
            catch(Exception)
            {
                this._maCollection = new ObservableCollection<ICartoObj>();
            }
        }
        #endregion

    }
}
