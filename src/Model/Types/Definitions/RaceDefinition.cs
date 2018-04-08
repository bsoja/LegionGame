namespace Legion.Model.Types.Definitions
{
    public class RaceDefinition : CharacterDefinition
    {
        /*
        '                e  s sz m b1 b2 int bob     
        Data "człowiek",30,25,25,20,2,0,10,18+63+48
         */

        public int Magic { get; set; }
        public int B1 { get; set; }
        public int B2 { get; set; }
        public int Intelligence { get; set; }
    }
}