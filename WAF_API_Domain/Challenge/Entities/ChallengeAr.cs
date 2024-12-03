namespace WAF_API_Domain.Note.Entities
{
    using WAF_API_Domain.Challenge.ValueObject;
    using WAF_API_Domain.Note.Dtos;
    using WAF_API_Domain.Note.ValueObject;
    using WAF_API_Domain.ValueObject;

    public class ChallengeAr
    {
        public Id Id { get; private set; }
        public Sentence Sentence { get; private set; }
        public Lang Lang { get; private set; }
        public Gamemodes Gamemodes { get; private set; }
        public Categories Categories { get; private set; }
        public IsChecked IsChecked { get; private set; }
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }
        public ChallengeAr(Id id, Sentence sentence, Lang lang, Gamemodes gamemodes, Categories categories, IsChecked isChecked)
        {
            Id = id;
            Sentence = sentence;
            Lang = lang;
            Gamemodes = gamemodes;
            Categories = categories;
            IsChecked = isChecked;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        public ChallengeAr(Id id, Sentence sentence, Lang lang, Gamemodes gamemodes, Categories categories)
        {
            Id = id;
            Sentence = sentence;
            Lang = lang;
            Gamemodes = gamemodes;
            Categories = categories;
            IsChecked = new IsChecked(false);
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        public ChallengeDto ToDto()
        {
            return new ChallengeDto
            {
                Id = Id.Value,
                Sentence = Sentence.Value,
                Lang = Lang.Value,
                Gamemodes = Gamemodes.Value,
                Categories = Categories.Value,
                IsCheked = IsChecked.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}
