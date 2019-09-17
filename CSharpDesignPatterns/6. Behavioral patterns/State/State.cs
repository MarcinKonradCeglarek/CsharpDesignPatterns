namespace CSharpDesignPatterns._6._Behavioral_patterns.State
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using CSharpDesignPatterns.Common.Model;

    /*
     * Document as state machine
     *
     * Initial state is Draft
     *
     * In Draft state:
     * - Document can be edited
     * - Document can be SubmittedForReview if it's not empty
     *
     * In SubmittedForReview state:
     * - Document can be edited
     * - Document can be reviewed (by others)
     * - Document can be Published if most recent approval from each reviewer is positive
     *
     * In Published state:
     * - no operations on document are permitted
     */
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