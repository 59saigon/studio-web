import { BaseView } from "./BaseView";

export interface WeddingView extends BaseView{
    weddingTittle: string;
    weddingDescription?: string | null;
    status?: string | null;
    startDate: Date;
    endDate: Date;
    //events: Event[];
}