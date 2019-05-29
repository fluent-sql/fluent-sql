using System.Threading.Tasks;

namespace WeelinkIT.FluentSQL.Tests
{
    public abstract class AsyncSpecification<T> : Specification<T>
    {
        protected override T EstablishContext()
        {
            return AsyncPump.Run(() => EstablishContextAsync());
        }

        protected override void Because(T sut)
        {
            AsyncPump.Run(() => BecauseAsync(sut));
        }

        protected override void CleanUpContext(T sut)
        {
            AsyncPump.Run(() => CleanUpContextAsync(sut));
        }

        protected virtual Task BecauseAsync(T sut)
        {
            return Task.CompletedTask;
        }

        protected virtual Task<T> EstablishContextAsync()
        {
            return Task.FromResult(default(T));
        }

        protected virtual Task CleanUpContextAsync(T sut)
        {
            return Task.CompletedTask;
        }
    }
}
