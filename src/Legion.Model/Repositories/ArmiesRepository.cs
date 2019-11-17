using System.Collections.Generic;
using System.Linq;
using Legion.Model.Types;
using Legion.Model.Types.Definitions;
using Legion.Utils;

namespace Legion.Model.Repositories
{
    public class ArmiesRepository : IArmiesRepository
    {
        private readonly IDefinitionsRepository _definitionsRepository;
        private readonly ICharactersRepository _charactersRepository;

        public ArmiesRepository(IDefinitionsRepository definitionsRepository,
            ICharactersRepository charactersRepository)
        {
            _definitionsRepository = definitionsRepository;
            _charactersRepository = charactersRepository;

            Armies = new List<Army>();
        }

        public List<Army> Armies { get; private set; }

        public Army CreateArmy(Player owner, int charactersCount, CharacterDefinition charactersType = null)
        {
            var army = new Army();
            army.Owner = owner;

            if (army.Owner != null)
            {
                var armyId = Armies.Count(a => a.Owner == army.Owner) + 1;

                if (army.Owner.IsUserControlled)
                {
                    army.Name = "Legion " + armyId;
                }
                else if (army.Owner.IsChaosControlled)
                {
                    army.Name = "Wojownicy Chaosu";
                    army.DaysToGetInfo = 30;
                }
                else
                {
                    var postfix = army.Owner.Name.StartsWith("I") ? "ego" : "a";
                    army.Name = armyId + " Legion " + army.Owner.Name + postfix;
                    army.DaysToGetInfo = 30;
                    //army.Aggression = 150 + Rand.Next(50) + dataManager.Power;
                }
            }

            army.Food = GlobalUtils.Rand(200);

            for (var i = 0; i < charactersCount; i++)
            {
                var type = charactersType;
                if (type == null)
                {
                    type = _definitionsRepository.Races[GlobalUtils.Rand(_definitionsRepository.Races.Count - 1)];
                }
                var character = _charactersRepository.CreateCharacter(type);
                army.Characters.Add(character);
            }

            Armies.Add(army);

            return army;
        }

        public Army CreateTempArmy(int charactersCount, CharacterDefinition charactersType = null)
        {
            var army = new Army();

            for (var i = 0; i < charactersCount; i++)
            {
                var type = charactersType;
                if (type == null)
                {
                    type = _definitionsRepository.Races[GlobalUtils.Rand(_definitionsRepository.Races.Count - 1)];
                }
                var character = _charactersRepository.CreateCharacter(type);
                army.Characters.Add(character);
            }

            return army;
        }

        public void KillArmy(Army army)
        {
            foreach (var a in Armies)
            {
                if (a.Target == army)
                {
                    a.Target = null;
                }
            }

            army.Characters.Clear();
            army.Target = null;

            if (Armies.Contains(army))
            {
                Armies.Remove(army);
            }
        }
    }
}