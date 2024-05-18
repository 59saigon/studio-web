import { Guid } from 'guid-typescript';
import { BaseEntity } from './BaseEntity';
import { EventXService } from './EventXService';

export interface Service extends BaseEntity {
    serviceTittle: string; // C# property mapped to TypeScript
    serviceDescription?: string; // Optional property
    type?: string; // Optional property
    price: number; // Non-optional double
    status?: string; // Optional property
    eventXServices?: EventXService[];
}
export interface ServiceGetAllQuery {
    serviceIds: Guid[]; // Sử dụng string[] nếu photoIds là các chuỗi UUID
}