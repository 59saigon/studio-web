import { BaseResult } from "./BaseResult";

export interface WeddingResult extends BaseResult{
    weddingTittle: string;
    weddingDescription?: string | null;
    status?: string | null;
    startDate: Date;
    endDate: Date;
    //events: Event[];
}