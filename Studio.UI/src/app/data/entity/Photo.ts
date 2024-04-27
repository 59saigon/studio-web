import { BaseEntity } from './BaseEntity';
import { EventXPhoto } from './EventXPhoto';

export interface Photo extends BaseEntity {
    photoName?: string; // Nullable string in C#
    url: string; // Non-nullable string
    eventXPhoto: EventXPhoto[];
}
