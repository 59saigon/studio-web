import { Guid } from 'guid-typescript';
import { BaseEntity } from './BaseEntity';
import { City } from './City';

export interface Location extends BaseEntity{
    locationName: string; // LocationName in C#
    cityId: Guid; // Guid represented as string
    city?: City; // Reference to City class, optional
    events?: Event[];

    
}
