using Microsoft.AspNet.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSC_Portal.Logic
{
    public class CustomExceptionFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        /**public void OnException(ExceptionContext context)
        {
            // todo: реализовать тут вывод сообщения об ошибке в лог
            var exception = context.Exception;
        }*/
    }
}
