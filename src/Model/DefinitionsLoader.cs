using System;
using System.Collections.Generic;
using System.IO;
using Legion.Model.Types.Definitions;

namespace Legion.Model
{
    public class DefinitionsLoader : IDefinitionsLoader
    {
        private const char separator = '|';
        private static readonly string BaseDir = "data";
        private static readonly string RaceTypesPath = BaseDir + Path.DirectorySeparatorChar + "race_types.csv";
        private static readonly string CreatureTypesPath = BaseDir + Path.DirectorySeparatorChar + "creature_types.csv";
        private static readonly string BuildingsTypesPath = BaseDir + Path.DirectorySeparatorChar + "building_types.csv";

        public List<CreatureDefinition> ReadCreatures()
        {
            var types = new List<CreatureDefinition>();

            var lines = File.ReadAllLines(CreatureTypesPath);
            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var type = new CreatureDefinition();
                types.Add(type);

                var fields = line.Split(new char[] { separator }, StringSplitOptions.None);

                //name     |energy|strength|speed|p1   |p2  |resistance |spell|bob
                type.Id = i;
                type.Name = fields[0].Trim();
                type.Energy = int.Parse(fields[1]);
                type.Strength = int.Parse(fields[2]);
                type.Speed = int.Parse(fields[3]);
                type.P1 = int.Parse(fields[4]);
                type.P2 = int.Parse(fields[5]);
                type.Resistance = int.Parse(fields[6]);
                type.Spell = int.Parse(fields[7]);
                type.Bob = fields[8].Trim();
            }

            return types;
        }

        public List<RaceDefinition> ReadRaces()
        {
            var types = new List<RaceDefinition>();

            var lines = File.ReadAllLines(RaceTypesPath);
            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var type = new RaceDefinition();
                types.Add(type);

                var fields = line.Split(new char[] { separator }, StringSplitOptions.None);

                //name     |energy|strength|speed|magic|b1|b2|intelligence|bob
                type.Id = i;
                type.Name = fields[0].Trim();
                type.Energy = int.Parse(fields[1]);
                type.Strength = int.Parse(fields[2]);
                type.Speed = int.Parse(fields[3]);
                type.Magic = int.Parse(fields[4]);
                type.B1 = int.Parse(fields[5]);
                type.B2 = int.Parse(fields[6]);
                type.Intelligence = int.Parse(fields[7]);
                type.Bob = fields[8].Trim();
            }

            return types;
        }

        public List<BuildingDefinition> ReadBuildings()
        {
            var types = new List<BuildingDefinition>();

            var lines = File.ReadAllLines(BuildingsTypesPath);
            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var type = new BuildingDefinition();
                types.Add(type);

                var fields = line.Split(new char[] { separator }, StringSplitOptions.None);

                //name      |width|height|price|time|b1|b2|doors
                type.Id = i;
                type.Name = fields[0].Trim();
                type.Width = int.Parse(fields[1]);
                type.Height = int.Parse(fields[2]);
                type.Price = int.Parse(fields[3]);
                type.Time = int.Parse(fields[4]);
                type.B1 = int.Parse(fields[5]);
                type.B2 = int.Parse(fields[6]);
                type.Doors = int.Parse(fields[7]);
                //type.Bob = fields [8].Trim ();
            }

            return types;
        }
    }
}