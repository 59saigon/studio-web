import { BaseView } from "../base/BaseView";

export interface WeddingView extends BaseView{
    weddingTittle: string;
    weddingDescription?: string | null;
    status?: string | null;
    startDate: Date;
    endDate: Date;
}