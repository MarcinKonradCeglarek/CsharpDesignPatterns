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
        public IReadOnlyDictionary<User, bool> Approvals =>
            new ReadOnlyDictionary<User, bool>(
                this.reviews.GroupBy(r => r.reviewer).ToDictionary(g => g.Key, g => g.Last().approval));

        public void Edit(string changes)
        {
            this.state.Edit(changes);
        }

        public void SubmitForReview()
        {
            this.state.SubmitForReview();
        }

        public void Review(User reviewer, bool approval)
        {
            this.state.Review(reviewer, approval);
        }

        public void Publish()
        {
            this.state.Publish();
        }

        public class DraftState : IDocument
        {
            private readonly Document document;

            public DraftState(Document document)
            {
                this.document = document;
            }

            public void Edit(string changes)
            {
                this.document.contents = changes;
            }

            public void SubmitForReview()
            {
                /*
                 * if document.contents is empty
                 *    throw Document's content can't be empty
                 * else
                 *    submit for review
                 */
                if (string.IsNullOrEmpty(this.document.Contents))
                {
                    throw new InvalidOperationException("Document's content can't be empty");
                }

                this.document.state = new UnderReviewState(this.document);
            }

            public void Review(User reviewer, bool approval)
            {
                throw new InvalidOperationException("Draft can't be reviewed");
            }

            public void Publish()
            {
                throw new InvalidOperationException("Draft can't be published");
            }
        }

        public class UnderReviewState : IDocument
        {
            private readonly Document document;

            public UnderReviewState(Document document)
            {
                this.document = document;
            }

            public void Edit(string changes)
            {
                this.document.contents = changes;
            }

            public void SubmitForReview()
            {
                throw new InvalidOperationException("Document is already under review");
            }

            public void Review(User reviewer, bool approval)
            {
                var newReview = (reviewer, approval);
                this.document.reviews.Add(newReview);
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
                if (!this.document.Approvals.Any())
                {
                    throw new InvalidOperationException("Can't publish document without at least one approval");
                }

                if (this.document.Approvals.All(a => a.Value))
                {
                    this.document.state = new PublishedState();
                }
                else
                {
                    throw new InvalidOperationException("Can't publish document with failed reviews");
                }
            }
        }

        public class PublishedState : IDocument
        {
            public void Edit(string changes)
            {
                throw new InvalidOperationException("Published document can't be edited");
            }

            public void SubmitForReview()
            {
                throw new InvalidOperationException("Published document can't be submitted for review");
            }

            public void Review(User reviewer, bool approval)
            {
                throw new InvalidOperationException("Published document can't be reviewed");
            }

            public void Publish()
            {
                throw new InvalidOperationException("Published document can't be published");
            }
        }
    }
}