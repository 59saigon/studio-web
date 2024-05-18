import { Guid } from "guid-typescript";
import { BaseEntity } from "./BaseEntity";
import { EventEntity } from "./Event";
import { Photo } from "./Photo";

export interface EventXPhoto extends BaseEntity{
    eventId: Guid,
    photoId: Guid,
    event: EventEntity,
    photo: Photo
}