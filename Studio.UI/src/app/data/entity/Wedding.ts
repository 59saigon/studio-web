import { BaseEntity } from "./BaseEntity";

export interface Wedding extends BaseEntity{
    weddingTittle: string;
    weddingDescription?: string | null;
    status?: string | null;
    startDate: Date;
    endDate: Date;
    //events: Event[];
}