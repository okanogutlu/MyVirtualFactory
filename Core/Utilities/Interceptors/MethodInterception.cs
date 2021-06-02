using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { } //invocation = add,getall gibi senin business methodlar
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        
        public override void Intercept(IInvocation invocation) //Aynı klasör içindeki "MethodInterceptionBaseAttribute class'ından override ettik.
        {
            var isSuccess = true; //default true yaptık
            OnBefore(invocation);//method işlenmeden yapılacaklar
            try
            {
                invocation.Proceed(); //methodu işlemeye çalış
            }
            catch (Exception e) //eğer ki hata alırsan
            {
                isSuccess = false;//boolean'ı false yap
                OnException(invocation, e);//exception'da yapılacakları yap
                throw;
            }
            finally//en son
            {
                if (isSuccess)//eğer ki işlem başarılıysa
                {
                    OnSuccess(invocation); //başarılı olunca yapılacakları yap
                }
            }
            OnAfter(invocation);//method işlendikten sonra yapılacakları yap.
        }
    }
}
