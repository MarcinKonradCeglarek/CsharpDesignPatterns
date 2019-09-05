namespace CSharpDesignPatterns._6._Behavioral_patterns.State
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CSharpDesignPatterns.Common.Model;

    public interface IDocument
    {
        void Edit(string changes);
        void SubmitForReview();
        void Review(User reviewer, bool approval);
        void Publish();
    }

    public class Document : IDocument
    {
        private readonly User author;
        private readonly IList<(User reviewer, bool approval)> reviews = new List<(User reviewer, bool approval)>();
        private IDocument state;
        private string contents;

        public Document(User author)
        {
            this.author = author;
            this.state = new DraftState(this);
        }

        public bool IsPublished => this.state is PublishedState;
        public bool IsDraft => this.state is DraftState;
        public bool IsUnderReview => this.state is UnderReviewState;
        public string Contents => this.contents;
        public Dictionary<User, bool> Approvals =>
            this.reviews.GroupBy(r => r.reviewer).ToDictionary(g => g.Key, g => g.Last().approval);

        public void Edit(string changes)
        {
        }

        public void SubmitForReview()
        {
        }

        public void Review(User reviewer, bool approval)
        {
        }

        public void Publish()
        {
        }

        public class DraftState : IDocument
        {
            public DraftState(Document document)
            {
            }

            public void Edit(string changes)
            {
                // update contents
            }

            public void SubmitForReview()
            {
                /*
                 * if document.contents is empty
                 *    throw Document's content can't be empty
                 * else
                 *    submit for review
                 */
            }

            public void Review(User reviewer, bool approval)
            {
                // Draft can't be reviewed
            }

            public void Publish()
            {
                // Draft can't be published
            }
        }

        public class UnderReviewState : IDocument
        {
            public UnderReviewState(Document document)
            {
            }

            public void Edit(string changes)
            {
                // update contents
            }

            public void SubmitForReview()
            {
                // Document is already under review
            }

            public void Review(User reviewer, bool approval)
            {
                // Add review
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
            }
        }

        public class PublishedState : IDocument
        {
            public void Edit(string changes)
            {
                // Published document can't be edited
            }

            public void SubmitForReview()
            {
                // Published document can't be submitted for review
            }

            public void Review(User reviewer, bool approval)
            {
                // Published document can't be reviewed
            }

            public void Publish()
            {
                // Published document can't be published
            }
        }
    }
}