namespace Legion.Model.Types.Definitions
{
    public class CreatureDefinition : CharacterDefinition
    {
        /*'potworki       e  s  sz p1 p2 od czar bob           
           Data "gargoil",100,80,25,78,85,50,0,18+63+128+32*/

        public int P1 { get; set; }
        public int P2 { get; set; }
        public int Resistance { get; set; }
        public int Spell { get; set; }
    }
}