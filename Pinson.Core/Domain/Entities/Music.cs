using Pinson.Core.Domain.Constants;
using Pinson.Core.Domain.Exceptions;
using Pinson.Core.Domain.ValueObjects;

namespace Pinson.Core.Domain.Entities
{
    public class Title(string title) : Name(title, Limits.MUSIC_NAME_LENGTH_LIMIT)
    {
    }

    public class Music
    {
        private HashSet<Guid> _artistIds = [];

        public Music(
            Guid id, 
            Title title, 
            DateTime importDate, 
            Count listenCount, 
            TimeSpan duration, 
            IReadOnlyCollection<Guid> artistIds, 
            Guid? thumbnailId = null
            )
        {
            _artistIds = [.. artistIds];

            Id = id;
            Title = title;
            ImportDate = importDate;
            ListenCount = listenCount;
            Duration = duration;
            ThumbnailId = thumbnailId;
        }

        public Guid Id { get; }
        public DateTime ImportDate { get; }
        public Count ListenCount { get; }
        public TimeSpan Duration { get; }

        public Title Title { get; private set; }
        public Guid? ThumbnailId { get; private set; }

        public IReadOnlyCollection<Guid> ArtistIds => _artistIds;

        public void SetTitle(Title newTitle)
        {
            Title = newTitle;
        }

        public void SetThumbnail(Guid thumbnailId)
        {
            ThumbnailId = thumbnailId;
        }

        public void RemoveThumbnail()
        {
            ThumbnailId = null;
        }

        public void IncrementListen()
        {
            ListenCount.Increment();
        }

        public void AddArtist(Guid artistId)
        {
            if (!_artistIds.Add(artistId))
            {
                throw new AlreadyExistsException();
            }
        }

        public void RemoveArtist(Guid artistId)
        {
            if (!_artistIds.Remove(artistId))
            {
                throw new NotFoundException();
            }
        }
    }
}
