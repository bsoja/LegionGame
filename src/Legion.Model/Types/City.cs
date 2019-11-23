using System.Collections.Generic;

namespace Legion.Model.Types
{
    public class City : MapObject
    {
        private static int _id;

        public City()
        {
            PriceModificators = new Dictionary<string, int>();
            Buildings = new List<Building>();

            Id = ++_id;
        }

        public override MapObjectType Type => MapObjectType.City;

        //public int Id { get; set; }

        /// <summary>
        /// MIASTA$
        /// </summary>
        //public string Name { get; set; }

        /// <summary>
        /// M_X=1
        /// </summary>
        //public int X { get; set; }

        /// <summary>
        /// M_Y=2
        /// </summary>
        //public int Y { get; set; }

        /// <summary>
        /// M_LUDZIE=3
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// M_PODATEK=4
        /// </summary>
        public int Tax { get; set; }

        /// <summary>
        /// M_CZYJE=5
        /// </summary>
        //public Player Owner { get; set; }

        /// <summary>
        /// M_MORALE=6
        /// </summary>
        public int Morale { get; set; }

        /// <summary>
        /// M_MUR=0
        /// </summary>
        public int WallType { get; set; }

        public int BobId { get; set; }

//        /// <summary>
//        /// TEREN=MIASTA(MIASTO,1,M_X)
//        /// </summary>
//        public int TerrainType { get; set; }

        /// <summary>
        /// SZAJBA=MIASTA(M,1,M_MORALE)
        /// </summary>
        public int Craziness { get; set; }

        /// <summary>
        /// DNI=MIASTA(NR,1,M_Y)
        /// </summary>
        public int DaysToGetInfo { get; set; }

        /// <summary>
        /// DNI=MIASTA(MIASTO,1,M_PODATEK)
        /// </summary>
        public int DaysToSetNewRecruiters { get; set; }

        /// <summary>
        /// MIASTA(M,1,M_LUDZIE)
        /// </summary>
        public int Food { get; set; }

        /// <summary>
        /// MIASTA(I,J,M_MUR)=Rnd(WAHANIA)
        /// Price Modificators for city, item name is a key, and value is price modificator for this item
        /// </summary>
        public Dictionary<string, int> PriceModificators { get; set; }

		/// <summary>
		///    If LUDZIE>700 M$="Miasto : " Else M$="Osada  : " End If
		/// </summary>
		/// <value><c>true</c> if is big city; otherwise, <c>false</c>.</value>
		public bool IsBigCity => Population > 700;

        public List<Building> Buildings { get; set; }
    }
}