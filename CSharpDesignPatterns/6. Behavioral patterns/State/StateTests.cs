namespace CSharpDesignPatterns._6._Behavioral_patterns.State
{
    using System;

    using CSharpDesignPatterns.Common.Model;

    using NUnit.Framework;

    [TestFixture]
    public class StateTests
    {
        private readonly User moderator  = new User("Moderator",  UserRole.Moderator);
        private readonly User moderator2 = new User("Moderator2", UserRole.Moderator);
        private readonly User user       = new User("User",       UserRole.User);

        [Test]
        public void CreatesDocumentInDraftState()
        {
            var document = new Document(this.user);

            Assert.IsTrue(document.IsDraft);
            Assert.IsFalse(document.IsPublished);
            Assert.IsFalse(document.IsUnderReview);
        }

        [Test]
        public void DocumentInDraftStateCanBeEdited()
        {
            var newContents = Guid.NewGuid().ToString();
            var document    = new Document(this.user);
            document.Edit(newContents);

            Assert.AreEqual(newContents, document.Contents);
        }

        [Test]
        public void DocumentInDraftStateCantBePublished()
        {
            var document  = new Document(this.user);
            var exception = Assert.Throws<InvalidOperationException>(() => document.Publish());

            Assert.AreEqual("Draft can't be published", exception.Message);
        }

        [Test]
        public void DocumentInDraftStateCantBeReviewed()
        {
            var document  = new Document(this.user);
            var exception = Assert.Throws<InvalidOperationException>(() => document.Review(this.moderator, true));

            Assert.AreEqual("Draft can't be reviewed", exception.Message);
        }

        [Test]
        public void DocumentSubmittedForReviewCanBeEdited()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            var newContents = Guid.NewGuid().ToString();
            document.Edit(newContents);
            Assert.AreEqual(newContents, document.Contents);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void DocumentSubmittedForReviewCanBeReviewed(bool approval)
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            document.Review(this.moderator, approval);

            Assert.AreEqual(1,        document.Approvals.Count);
            Assert.AreEqual(approval, document.Approvals[this.moderator]);
        }

        [Test]
        public void DocumentSubmittedForReviewCantBePublishedWithFailingReview()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            document.Review(this.moderator, false);
            var exception = Assert.Throws<InvalidOperationException>(() => document.Publish());
            Assert.AreEqual("Can't publish document with failed reviews", exception.Message);
        }

        [Test]
        public void DocumentSubmittedForReviewCantBePublishedWithoutReview()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            var exception = Assert.Throws<InvalidOperationException>(() => document.Publish());
            Assert.AreEqual("Can't publish document without at least one approval", exception.Message);
        }

        [Test]
        public void DocumentSubmittedForReviewCantBeSubmittedForReview()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            var exception = Assert.Throws<InvalidOperationException>(() => document.SubmitForReview());
            Assert.AreEqual("Document is already under review", exception.Message);
        }

        [Test]
        public void DocumentSubmittedForReviewWithOneFailingAndOnePassingReviewCantBePublished()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            document.Review(this.moderator2, false);
            document.Review(this.moderator,  false);
            document.Review(this.moderator,  true);

            var exception = Assert.Throws<InvalidOperationException>(() => document.Publish());
            Assert.AreEqual("Can't publish document with failed reviews", exception.Message);
        }

        [Test]
        public void DocumentSubmittedForReviewWithOneFailingThanPassingReviewCanBePublished()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            document.Review(this.moderator, false);
            document.Review(this.moderator, true);
            document.Publish();
            Assert.AreEqual(true, document.IsPublished);
        }

        [Test]
        public void DocumentSubmittedForReviewWithPassingThenFailingReviewCantBePublished()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            document.Review(this.moderator2, true);
            document.Review(this.moderator,  true);
            document.Review(this.moderator,  false);

            var exception = Assert.Throws<InvalidOperationException>(() => document.Publish());
            Assert.AreEqual("Can't publish document with failed reviews", exception.Message);
        }

        [Test]
        public void DocumentSubmittedForReviewWithTwoFailingThenTwoPassingReviewCanBePublished()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            document.Review(this.moderator2, false);
            document.Review(this.moderator,  false);
            document.Review(this.moderator,  true);
            document.Review(this.moderator2, true);

            document.Publish();
            Assert.AreEqual(true, document.IsPublished);
        }

        [Test]
        public void DocumentWithContentsInDraftStateCanBeSubmittedForReview()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();

            Assert.IsTrue(document.IsUnderReview);
        }

        [Test]
        public void EmptyDocumentInDraftStateCantBeSubmittedForReview()
        {
            var document  = new Document(this.user);
            var exception = Assert.Throws<InvalidOperationException>(() => document.SubmitForReview());

            Assert.AreEqual("Document's content can't be empty", exception.Message);
        }

        [Test]
        public void PublishedDocumentCantBeEdited()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();
            document.Review(this.moderator, true);
            document.Publish();

            var exception = Assert.Throws<InvalidOperationException>(() => document.Edit("newChange"));
            Assert.AreEqual("Published document can't be edited", exception.Message);
        }

        [Test]
        public void PublishedDocumentCantBePublished()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();
            document.Review(this.moderator, true);
            document.Publish();

            var exception = Assert.Throws<InvalidOperationException>(() => document.Publish());
            Assert.AreEqual("Published document can't be published", exception.Message);
        }

        [Test]
        public void PublishedDocumentCantBeReviewed()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();
            document.Review(this.moderator, true);
            document.Publish();

            var exception = Assert.Throws<InvalidOperationException>(() => document.Review(this.moderator, false));
            Assert.AreEqual("Published document can't be reviewed", exception.Message);
        }

        [Test]
        public void PublishedDocumentCantBeSubmittedForReview()
        {
            var document = new Document(this.user);
            document.Edit(Guid.NewGuid().ToString());
            document.SubmitForReview();
            document.Review(this.moderator, true);
            document.Publish();

            var exception = Assert.Throws<InvalidOperationException>(() => document.SubmitForReview());
            Assert.AreEqual("Published document can't be submitted for review", exception.Message);
        }
    }
}