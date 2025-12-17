using Seido.Utilities.SeedGenerator;

namespace Models.Music;

public enum MusicGenre {Rock, Blues, Jazz, Metal}
public class MusicGroup : ISeed<MusicGroup>
{
    public virtual Guid MusicGroupId { get; set; }
    public virtual string Name { get; set; }
    public virtual int EstablishedYear { get; set; }

    public virtual MusicGenre Genre { get; set; }
 
    #region Constructors
    public MusicGroup(){}
    public MusicGroup(MusicGroup org)
    {
        MusicGroupId = org.MusicGroupId;
        Name = org.Name;
        EstablishedYear = org.EstablishedYear;
        Genre = org.Genre;
    }
    #endregion

    #region randomly seed this instance
    public virtual bool Seeded { get; set; } = false;
    public virtual MusicGroup Seed(SeedGenerator seedGenerator)
    {
        Seeded = true;
        MusicGroupId = Guid.NewGuid();

        Name = seedGenerator.MusicGroupName;
        EstablishedYear = seedGenerator.Next(1970, 2024);
        Genre = seedGenerator.FromEnum<MusicGenre>();
        return this;
    }
    #endregion
}


