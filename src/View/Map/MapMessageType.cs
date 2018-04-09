namespace Legion.View.Map
{
    public enum MapMessageType
    {
        RiotInTheCity, //W mieście wybuchł bunt ! 
        RiotInTheCityWithDefence, //A$="W mieście wybuchł bunt ! " + ARMIA$(_ATAK,0) + " będzie walczyć z rebeliantami."
        RiotInTheCitySuccess, //A$="Rebelianci przejęli miasto."

        //Plague:
        FireBurnsPeopleAndCity, //A$="Płomienie strawiły wielu miaszkańców i ich domostwa."
        EpidemyInsideCity, //A$="Epidemia zarazy kosi swe śmiertelne żniwo ! "
        AllFoodsEatenByRats, //A$="Szczury pożarły cały zapas zboża w spichlerzach."

        EnemyAttacksUserCity, // MESSAGE[A,"atakuj"+KON$+" naszą osadę "+A$+" ",0,0]
        UserAttackCity, //MESSAGE[A,"Rozpoczynamy atak na osadę "+A$,0,0]
        ChaosWarriorsBurnsCity, //MESSAGE2[B,"Wojownicy Chaosu spalili miasto.",32,1,0]
        EnemyCapturedUserCity, //MESSAGE2[A,"zdobył naszą osadę "+A$+" ",30,0,0] // MESSAGE[A, "zajął naszą osadę " + A$+" ", 0, 0]
        UserCapturedCity, //MESSAGE2[A,"Zdobyliśmy osadę "+A$+" ",30,0,0]
        UserArmyFailedToCaptureCity, //MESSAGE2[A, "został rozbity w czasie szturmu na miasto " + A$, 33, 0, 0]
    }
}