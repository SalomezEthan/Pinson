using Pinson.Core.Domain.Entities;
using Pinson.Core.Domain.Exceptions;
using Pinson.Core.Domain.ValueObjects;

namespace Pinson.Core.Tests.Domain.Entities
{
    [TestClass]
    public class MusicTests
    {
        [TestMethod]
        public void SetTitle_ValidTitle_UpdateMusicTitle()
        {
            var music = GetTestMusic();
            var title = new Title("Mon nouveau nom de musique");
            music.SetTitle(title);
            Assert.AreEqual(title, music.Title);
        }

        [TestMethod]
        public void SetThumbnail_NewGuid_UpdateThumbnail()
        {
            var music = GetTestMusic();
            var newThumbId = Guid.NewGuid();
            music.SetThumbnail(newThumbId);
            Assert.AreEqual(newThumbId, music.ThumbnailId);
        }

        [TestMethod]
        public void RemoveThumbnail_UpdateThumbnailByNull()
        {
            var music = GetTestMusic();
            music.RemoveThumbnail();
            Assert.IsNull(music.ThumbnailId);
        }

        [TestMethod]
        public void AddArtist_AlreadyExistsArtistId_Throw()
        {
            var music = GetTestMusic();
            var artistId = music.ArtistIds.First();
            Assert.ThrowsExactly<AlreadyExistsException>(() => music.AddArtist(artistId));
        }

        [TestMethod]
        public void RemoveArtist_UnknownArtistId_Throw()
        {
            var music = GetTestMusic();
            var artistId = Guid.NewGuid();
            Assert.ThrowsExactly<NotFoundException>(() => music.RemoveArtist(artistId));
        }

        [TestMethod]
        public void IncrementListenCount_UpdateCount()
        {
            var music = GetTestMusic();
            var oldCount = music.ListenCount;
            music.IncrementListenCount();
            Assert.AreNotEqual(oldCount, music.ListenCount);
        }

        private static Music GetTestMusic()
        {
            return new Music(
                id: Guid.NewGuid(),
                title: new Title("Mon titre"),
                importDate: DateTime.Now,
                listenCount: new Count(0),
                duration: TimeSpan.FromMinutes(2),
                artistIds: [Guid.NewGuid()],
                thumbnailId: Guid.NewGuid()
                );
        }
    }
}
