import { Guid } from "guid-typescript";
import { BaseEntity } from "./BaseEntity";
import { EventEntity } from "./Event";
import { Service } from "./Service";

export interface EventXService extends BaseEntity{
    eventId: Guid,
    serviceId: Guid,
    event: EventEntity,
    service: Service
}