using BS.Domain.Common.Models;

namespace BS.Domain.MenuReview.ValueObjects
{
    public sealed class MenuReviewId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId CreateUnique()
        {
            return new MenuReviewId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
