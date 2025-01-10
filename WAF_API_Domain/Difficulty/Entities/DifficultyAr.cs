using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Dtos;
using WAF_API_Domain.Difficulty.Dtos;
using WAF_API_Domain.ValueObject;

namespace WAF_API_Domain.Difficulty.Entities
{
    public class DifficultyAr
    {
        public Id Id { get; private set; }
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }
        
        public DifficultyName DifficultyName { get; set; }
        public Notation DifficultyNotation { get; set; }
        public Notation DareNotation { get; set; }
        public Notation TruthNotation { get; set; }
        public Notation NeverHaveIEverNotation { get; set; }
        public Notation ParanoiaNotation { get; set; }
        public Notation WouldYouRatherNotation { get; set; }
        
        public DifficultyAr(Id id, DifficultyName difficultyName) 
        {
            Id = id;
            DifficultyName = difficultyName;
            DifficultyNotation = new Notation();
            DareNotation = new Notation();
            TruthNotation = new Notation();
            NeverHaveIEverNotation = new Notation();
            ParanoiaNotation = new Notation();
            WouldYouRatherNotation = new Notation();
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        public DifficultyAr(Id id, DifficultyName difficultyName, Notation difficultyNotation, Notation dareNotation, Notation truthNotation, Notation neverHaveIEver, Notation paranoiaNotation, Notation wouldYouRatherNotation ) 
        {
            Id = id;
            DifficultyName = difficultyName;
            DifficultyNotation = difficultyNotation;
            DareNotation = dareNotation;
            TruthNotation = truthNotation;
            NeverHaveIEverNotation = neverHaveIEver;
            ParanoiaNotation = paranoiaNotation;
            WouldYouRatherNotation = wouldYouRatherNotation;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        public DifficultyDto ToDto()
        {
            return new DifficultyDto()
            {
                Id = Id.Value,
                DifficultyName = DifficultyName.Value,
                DifficultyNotation = DifficultyNotation.Value,
                DareNotation = DareNotation.Value,
                TruthNotation = TruthNotation.Value,
                NeverHaveIEverNotation = NeverHaveIEverNotation.Value,
                ParanoiaNotation = ParanoiaNotation.Value,
                WouldYouRatherNotation = WouldYouRatherNotation.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}