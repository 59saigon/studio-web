import { Guid } from 'guid-typescript';
import { BaseEntity } from './BaseEntity';
import { Wedding } from './Wedding';
import { Photo } from './Photo';
import { Service } from './Service';
import { EventXService } from './EventXService';

export interface Event extends BaseEntity {
    eventTitle: string; // EventTittle in C#
    eventDescription?: string; // ? indicates optional
    weddingId?: Guid; // Guid represented as string
    locationId?: Guid; // Guid represented as string
    status?: string; // Optional string
    wedding?: Wedding; // Reference to Wedding class
    location?: Location; // Reference to Location class
    photos?: Photo[]; // Array of Photo objects
    eventXServices?: EventXService[]; // Array of Service objects
}
