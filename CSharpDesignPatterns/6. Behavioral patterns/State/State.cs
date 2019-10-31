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
     *      State changed to SubmittedForReview
     *
     * In SubmittedForReview state:
     * - Document can be edited
     * - Document can be reviewed (by others)
     * - Document can be Published if have at least one approval and most recent approval from each reviewer is positive
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
            this.author = author;
            this.state  = new DraftState(this);
        }

        public IReadOnlyDictionary<User, bool> Approvals =>
            new ReadOnlyDictionary<User, bool>(
                this.reviews.GroupBy(r => r.reviewer).ToDictionary(g => g.Key, g => g.Last().approval));
        public string Contents { get; private set; }

        public bool IsDraft => this.state is DraftState;

        public bool IsPublished   => this.state is PublishedState;
        public bool IsUnderReview => this.state is UnderReviewState;

        public void Edit(string changes)
        {
            this.state.Edit(changes);
        }

        public void Publish()
        {
            this.state.Publish();
        }

        public void Review(User reviewer, bool approval)
        {
            this.state.Review(reviewer, approval);
        }

        public void SubmitForReview()
        {
            this.state.SubmitForReview();
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
                this.document.Contents = changes;
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
                if (string.IsNullOrEmpty(this.document.Contents))
                {
                    throw new InvalidOperationException("Document's content can't be empty");
                }

                this.document.state = new UnderReviewState(this.document);
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
            private readonly Document document;

            public UnderReviewState(Document document)
            {
                this.document = document;
            }

            public void Edit(string changes)
            {
                this.document.Contents = changes;
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

            public void Review(User reviewer, bool approval)
            {
                var newReview = (reviewer, approval);
                this.document.reviews.Add(newReview);
            }

            public void SubmitForReview()
            {
                throw new InvalidOperationException("Document is already under review");
            }
        }
    }
}