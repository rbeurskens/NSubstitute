using System;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace NSubstitute.Specs.Infrastructure
{
    public static class MockingAdaptor
    {
        public static T Create<T>() where T : class
        {
            return MockRepository.GenerateStub<T>();
        }

        public static void received<T>(this T mock, Action<T> callReceived)
        {
            mock.AssertWasCalled(callReceived);
        }

        public static void did_not_receive<T>(this T mock, Action<T> call)
        {
            mock.AssertWasNotCalled(call);    
        }

        public static void did_not_receive_with_any_args<T>(this T mock, Action<T> call)
        {
            mock.AssertWasNotCalled(call, options => options.IgnoreArguments());

        }

        public static IMethodOptions<object> stub<T>(this T mock, Action<T> call) where T : class
        {
            return mock.Stub(call);
        }

        public static IMethodOptions<R> stub<T, R>(this T mock, Func<T, R> call) where T : class
        {
            Function<T, R> function = t => call(t);
            return mock.Stub(function);
        }
    }
}