﻿using Studio.API.Business.Domain.Models.Base;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.Business.Domain.Utilities
{
    public class AppMessage
    {
        public static MessageResults<TResult> GetMessageResults<TResult>(List<TResult> results)
            where TResult : BaseResult
        {
            return new MessageResults<TResult>(results);
        }

        public static MessageResult<TResult> GetMessageResult<TResult>(TResult result)
            where TResult : BaseResult
        {
            return new MessageResult<TResult>(result);
        }

        public static MessageViews<TView> GetMessageViews<TView>(List<TView> views)
            where TView : BaseView
        {
            return new MessageViews<TView>(views);
        }

        public static MessageView<TView> GetMessageView<TView>(TView view)
            where TView : BaseView
        {
            return new MessageView<TView>(view);
        }
    }
}
