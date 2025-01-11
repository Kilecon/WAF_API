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
        
        public ValueObject.DifficultyName DifficultyName { get; set; }
        public Mark DifficultyNotation { get; set; }
        public Mark DareNotation { get; set; }
        public Mark TruthNotation { get; set; }
        public Mark NeverHaveIEverNotation { get; set; }
        public Mark ParanoiaNotation { get; set; }
        public Mark WouldYouRatherNotation { get; set; }
        
        public DifficultyAr(Id id, ValueObject.DifficultyName difficultyName) 
        {
            Id = id;
            DifficultyName = difficultyName;
            DifficultyNotation = new Mark();
            DareNotation = new Mark();
            TruthNotation = new Mark();
            NeverHaveIEverNotation = new Mark();
            ParanoiaNotation = new Mark();
            WouldYouRatherNotation = new Mark();
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        public DifficultyAr(Id id, ValueObject.DifficultyName difficultyName, Mark difficultyNotation, Mark dareNotation, Mark truthNotation, Mark neverHaveIEver, Mark paranoiaNotation, Mark wouldYouRatherNotation ) 
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