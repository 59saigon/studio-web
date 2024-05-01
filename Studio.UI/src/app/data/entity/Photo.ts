import { Guid } from 'guid-typescript';
import { BaseEntity } from './BaseEntity';
import { EventXPhoto } from './EventXPhoto';

export interface Photo extends BaseEntity {
    photoName?: string; // Nullable string in C#
    url: string; // Non-nullable string
    eventXPhotos: EventXPhoto[];
}

export interface PhotoGetAllQuery {
    fromDate: Date;
    toDate: Date;
    photoIds: Guid[]; // Sử dụng string[] nếu photoIds là các chuỗi UUID
}