﻿using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Events;

namespace Studio.API.Business.Domain.CQRS.Commands.Events.EventXServices
{
    public class EventXServiceDeleteCommand : DeleteCommand<EventXServiceView>
    {
    }
}
