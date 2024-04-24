import { Guid } from "guid-typescript";
import { BaseEntity } from "./BaseEntity";
import { Event } from "./Event";
import { Service } from "./Service";

export interface EventXService extends BaseEntity{
    eventId: Guid,
    serviceId: Guid,
    event: Event,
    service: Service
}