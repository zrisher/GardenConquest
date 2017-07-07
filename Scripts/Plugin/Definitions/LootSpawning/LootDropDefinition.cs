/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using VRage;

using SEGarden.Definitions;
using SEGarden.Extensions;
using SEGarden.World;

namespace GC.Definitions.LootSpawning {

    [XmlType("LootDrop")]
    public class LootDropDefinition : DefinitionBase {

        [XmlAttribute("Probability")]
        public double Probability;

        [XmlAttribute("Type")]
        public String TypeName;

        [XmlAttribute("Subtype")]
        public String SubtypeName;

        [XmlAttribute("Count")]
        public double Count;

        protected override String ValidationName {
            get { return "LootDrop"; }
        }

        public LootDropDefinition() { }

        public LootDropDefinition(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            TypeName = stream.getString();
            SubtypeName = stream.getString();
            Count = stream.getDouble();
            Probability = stream.getDouble();
        }

         public void AddToByteSteam(ByteStream stream) {
             if (stream == null) throw new ArgumentException("null stream");

             stream.addString(TypeName);
             stream.addString(SubtypeName);
             stream.addDouble(Count);
             stream.addDouble(Probability);
         }

        public override void Validate(ref List<ValidationError> errors) {
            ErrorIf(String.IsNullOrWhiteSpace(TypeName),
                "TypeName cannot be empty.", ref errors);
            ErrorIf(String.IsNullOrWhiteSpace(SubtypeName),
                "SubtypeName cannot be empty.", ref errors);
            ErrorIf(Count < 0,
                "Count cannot be < 0.", ref errors);
            ErrorIf(Probability < 0 || Probability > 1,
                "Probability must be between 0 and 1 inclusive.", ref errors);

            try {
                new PhysicalItemType(TypeName, SubtypeName);
            }
            catch {
                var msg = String.Format(
                    "Unable to find item {0}/{1}", TypeName, SubtypeName
                );
                ErrorIf(false, msg, ref errors);
            }        
        }

    }

}
*/