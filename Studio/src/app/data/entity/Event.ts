import { Guid } from 'guid-typescript';
import { BaseEntity } from './BaseEntity';
import { Wedding } from './Wedding';
import { EventXService } from './EventXService';
import { EventXPhoto } from './EventXPhoto';
import { Location } from './Location';

export interface EventEntity extends BaseEntity {
    eventTittle: string; // EventTittle in C#
    eventDescription?: string; // ? indicates optional
    weddingId?: Guid; // Guid represented as string
    locationId?: Guid; // Guid represented as string
    status?: string; // Optional string
    wedding?: Wedding; // Reference to Wedding class
    location?: Location; // Reference to Location class
    eventXPhotos: EventXPhoto[];
    eventXServices?: EventXService[]; // Array of Service objects
}
