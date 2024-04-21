import { Guid } from "guid-typescript";
import { BaseResult } from "../base/BaseResult";
import { EventResult } from "../events/EventResult";

export interface ServiceResult extends BaseResult{
    serviceTittle: string;
    serviceDescription?: string | null;
    eventId: Guid;
    type?: string | null;
    price: number;
    status?: string | null;
    event: EventResult;
}