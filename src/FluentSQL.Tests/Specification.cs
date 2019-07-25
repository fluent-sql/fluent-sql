using System;

namespace FluentSQL.Tests
{
    public abstract class Specification<T> : IDisposable
    {
        protected Specification()
        {
            SetUp();
        }

        private T Sut { get; set; }

        public void Dispose()
        {
            CleanUpContext(Sut);

            if (Sut is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        private void SetUp()
        {
            Sut = EstablishContext();
            Because(Sut);
        }

        protected virtual T EstablishContext()
        {
            return default(T);
        }

        protected virtual void Because(T sut)
        {
        }

        protected virtual void CleanUpContext(T sut)
        {
        }
    }
}
