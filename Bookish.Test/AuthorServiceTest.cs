using System.Collections.Generic;
using NUnit.Framework;
using FakeItEasy;
using Bookish.Services;
using Bookish.Repositories;
using Bookish.Models.Database;

namespace Bookish.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AuthorService_ConvertsDbModelsToClasses()
    {
        // Arrange
        var fakeAuthorRepo = A.Fake<IAuthorRepo>();
        A.CallTo(() => fakeAuthorRepo.GetAllAuthors()).Returns(
            new List<AuthorDbModel>
            {
                new AuthorDbModel
                {
                    AuthorName = "Mr Bean",
                    AuthorPhotoUrl = "https://th.bing.com/th/id/R.857a2ad14ce5f4619c257c0d70c0639a?rik=GTqRayaA4Tl73g&pid=ImgRaw&r=0"
   
                },
                new AuthorDbModel
                {
                    AuthorName = "J. K. Rowling",
                    AuthorPhotoUrl = "https://th.bing.com/th/id/R.8d983f61347f12294ff9da87119b89f6?rik=Ng2OWiB9asVOdw&pid=ImgRaw&r=0"
   
                },                
            }
        );
        var service = new AuthorService(fakeAuthorRepo);

        // Act
        var authors = service.GetAllAuthors();

        // Assert
        Assert.That(authors, Has.Exactly(2).Items);
        Assert.That(authors[0].AuthorName, Is.EqualTo("Mr Bean"));
    }

        public void BookService_ConvertsDbModelsToClasses()
    {
        // Arrange
        var fakeBookRepo = A.Fake<IBookRepo>();
        A.CallTo(() => fakeBookRepo.GetAllBooks()).Returns(
            new List<BookDbModel>
            {
                new BookDbModel
                {
                    Title = "The Lord of the Rings",
                    Authors = new List<AuthorDbModel>
                    {
                        new AuthorDbModel
                        {
                            AuthorName = "J. R. R. Tolkien",
                        },
                    },
                    CoverPhotoUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1353467455l/13651.jpg",
                },
                new BookDbModel
                {
                    Title = "Leviathan Wakes",
                    Authors = new List<AuthorDbModel>
                    {
                        new AuthorDbModel
                        {
                            AuthorName = "James S.A. Corey",
                        },
                    },
                    CoverPhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/91Zzw-Mc5xL.jpg",
                },
            }
        );
        var service = new BookService(fakeBookRepo);

        // Act
        var books = service.GetAllBooks();

        // Assert
        Assert.That(books, Has.Exactly(2).Items);
        Assert.That(books[0].Title, Is.EqualTo("The Lord of the Rings"));
    }
}