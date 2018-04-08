using Legion.Model.Types.Definitions;

namespace Legion.Model.Types
{
    public class Building
    {
        /// <summary>
        /// MIASTA(I,J,M_X)=X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// MIASTA(I,J,M_Y)=Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// TYP=MIASTA(MIASTO,SNR,M_LUDZIE)
        /// </summary>
        public BuildingDefinition Type { get; set; }

        //not used: //PUPIL=MIASTA(MIASTO,SNR,M_PODATEK)
    }
}