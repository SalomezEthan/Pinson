using Pinson.Core.Domain.Entities;
using Pinson.Core.Domain.Exceptions;
using Pinson.Core.Domain.ValueObjects;

namespace Pinson.Core.Tests.Domain.Entities
{
    [TestClass]
    public class ArtistTests
    {
        [TestMethod]
        public void SetName_UpdateName()
        {
            var artist = CreateTestArtist();
            var oldName = artist.Name;
            var newName = new ArtistName("No");
            artist.SetName(newName);
            Assert.AreNotEqual(oldName, artist.Name);
            Assert.AreEqual(newName, artist.Name);
        }

        [TestMethod]
        public void IncrementMusicCount_UpdateMusicCount()
        {
            var artist = CreateTestArtist();
            var oldCount = artist.MusicCount;
            artist.IncrementMusicCount();
            Assert.AreNotEqual(oldCount, artist.MusicCount);
            Assert.AreEqual(oldCount.Increment(), artist.MusicCount);
        }

        [TestMethod]
        public void DecrementMusicCount_NegativeValue_Throw()
        {
            var artist = CreateTestArtist();
            Assert.ThrowsExactly<NegativeCountException>(() => artist.DecrementMusicCount());
        }

        [TestMethod]
        public void DecrementMusicCount_UpdateMusicCount()
        {
            var artist = CreateTestArtist();
            artist.IncrementMusicCount();

            var oldValue = artist.MusicCount;
            artist.DecrementMusicCount();

            Assert.AreNotEqual(oldValue, artist.MusicCount);
            Assert.AreEqual(oldValue.Decrement(), artist.MusicCount);
        }

        [TestMethod]
        public void SetPictureId_UpdatePictureId()
        {
            var artist = CreateTestArtist();
            var oldPicture = artist.PictureId;
            var newPicture = Guid.NewGuid();
            artist.SetPicture(newPicture);
            Assert.AreNotEqual(oldPicture, artist.PictureId);
            Assert.AreEqual(newPicture, artist.PictureId);
        }

        private Artist CreateTestArtist()
        {
            return new Artist(
                Guid.NewGuid(),
                new ArtistName("Hello"),
                new Count(0),
                Guid.NewGuid()
                );
        }
    }
}
