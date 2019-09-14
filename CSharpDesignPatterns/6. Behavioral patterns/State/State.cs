namespace CSharpDesignPatterns._6._Behavioral_patterns.State
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using CSharpDesignPatterns.Common.Model;

    public interface IDocument
    {
        void Edit(string changes);
        void Publish();
        void Review(User reviewer, bool approval);
        void SubmitForReview();
    }

    public class Document : IDocument
    {
        private readonly User                                  author;
        private readonly IList<(User reviewer, bool approval)> reviews = new List<(User reviewer, bool approval)>();
        private          IDocument                             state;

        public Document(User author)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<User, bool> Approvals => throw new NotImplementedException();
        public string Contents { get; private set; }

        public bool IsDraft => throw new NotImplementedException();
        public bool IsPublished   => throw new NotImplementedException();
        public bool IsUnderReview => throw new NotImplementedException();

        public void Edit(string changes)
        {
            throw new NotImplementedException();
        }

        public void Publish()
        {
            throw new NotImplementedException();
        }

        public void Review(User reviewer, bool approval)
        {
            throw new NotImplementedException();
        }

        public void SubmitForReview()
        {
            throw new NotImplementedException();
        }

        public class DraftState : IDocument
        {
            private readonly Document document;

            public DraftState(Document document)
            {
                throw new NotImplementedException();
            }

            public void Edit(string changes)
            {
                throw new NotImplementedException();
            }

            public void Publish()
            {
                throw new InvalidOperationException("Draft can't be published");
            }

            public void Review(User reviewer, bool approval)
            {
                throw new InvalidOperationException("Draft can't be reviewed");
            }

            public void SubmitForReview()
            {
                /*
                 * if document.contents is empty
                 *    throw Document's content can't be empty
                 * else
                 *    submit for review
                 */
                throw new NotImplementedException();
            }
        }

        public class PublishedState : IDocument
        {
            public void Edit(string changes)
            {
                throw new InvalidOperationException("Published document can't be edited");
            }

            public void Publish()
            {
                throw new InvalidOperationException("Published document can't be published");
            }

            public void Review(User reviewer, bool approval)
            {
                throw new InvalidOperationException("Published document can't be reviewed");
            }

            public void SubmitForReview()
            {
                throw new InvalidOperationException("Published document can't be submitted for review");
            }
        }

        public class UnderReviewState : IDocument
        {
            public UnderReviewState(Document document)
            {
                throw new NotImplementedException();
            }

            public void Edit(string changes)
            {
                throw new NotImplementedException();
            }

            public void Publish()
            {
                /*
                 * if document doesn't have approvals
                 *     throw Can't publish document without at least one approval
                 * else if all approvals are true
                 *     publish
                 * else
                 *     throw Can't publish document with failed reviews
                 */
                throw new NotImplementedException();
            }

            public void Review(User reviewer, bool approval)
            {
                throw new NotImplementedException();
            }

            public void SubmitForReview()
            {
                throw new InvalidOperationException("Document is already under review");
            }
        }
    }
}