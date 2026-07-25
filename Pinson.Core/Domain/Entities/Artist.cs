using Pinson.Core.Domain.Constants;
using Pinson.Core.Domain.ValueObjects;

namespace Pinson.Core.Domain.Entities
{
    public class ArtistName(string name) : Name(name, Limits.ARTIST_NAME_LENGTH_LIMIT)
    {
    }

    public class Artist
    {
        public Artist(
            Guid id, 
            ArtistName name, 
            Count musicCount, 
            Guid? pictureId
            )
        {
            Id = id;
            Name = name;
            MusicCount = musicCount;
            PictureId = pictureId;
        }

        public Guid Id { get; }
        public ArtistName Name { get; private set; }
        public Count MusicCount { get; private set; }
        public Guid? PictureId { get; private set; }

        public void DecrementMusicCount()
        {
            MusicCount = MusicCount.Decrement();
        }

        public void IncrementMusicCount()
        {
            MusicCount = MusicCount.Increment();
        }

        public void SetName(ArtistName newName)
        {
            Name = newName;
        }

        public void SetPicture(Guid newPicture)
        {
            PictureId = newPicture;
        }
    }
}
