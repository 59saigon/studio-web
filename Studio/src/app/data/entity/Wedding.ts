import { BaseEntity } from "./BaseEntity";
import { EventEntity } from "./Event";

export interface Wedding extends BaseEntity{
    weddingTittle: string;
    weddingDescription?: string | null;
    status?: string | null;
    startDate: Date;
    endDate: Date;
    events: EventEntity[];
}