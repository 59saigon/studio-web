import { Guid } from "guid-typescript";
import { BaseResult } from "../base/BaseResult";
import { EventResult } from "../events/EventResult";

export interface PhotoResult extends BaseResult{
    photoName?: string | null;
    url: string;
    eventId: Guid;
    event: EventResult;
}