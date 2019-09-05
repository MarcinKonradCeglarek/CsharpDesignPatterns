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
                if (!string.IsNullOrEmpty(this.document.contents))
                {
                    this.document.state = new UnderReviewState(this.document);
                }
                else
                {
                    throw new InvalidOperationException("Document's content can't be empty");
                }
            }

            public void Review(User reviewer, bool approval)
            {
                throw new InvalidOperationException($"Draft can't be reviewed");
            }

            public void Publish()
            {
                throw new InvalidOperationException($"Draft can't be published");
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
                this.document.reviews.Add((reviewer, approval));
            }

            public void Publish()
            {
                if (!this.document.Approvals.Any())
                {
                    throw new InvalidOperationException("Can't publish document without at least one approval");
                }
                else if (this.document.Approvals.All(r => r.Value))
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