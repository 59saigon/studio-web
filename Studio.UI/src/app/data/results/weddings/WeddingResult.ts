import { BaseResult } from "../base/BaseResult";
import { EventResult } from "../events/EventResult";

export interface WeddingResult extends BaseResult{
    weddingTittle: string;
    weddingDescription?: string | null;
    status?: string | null;
    startDate: Date;
    endDate: Date;
    events: EventResult[];
}