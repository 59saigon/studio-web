import { Guid } from 'guid-typescript';
import { BaseEntity } from './BaseEntity';
import { Event } from './Event';

export interface Photo extends BaseEntity {
    photoName?: string; // Nullable string in C#
    url: string; // Non-nullable string
    eventId: Guid; // Guid represented as a string
    event?: Event;
}
