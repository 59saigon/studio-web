import { Guid } from "guid-typescript";

export interface BaseResult{
    id: Guid;
    createdBy: string;
    createdDate: Date;
    lastUpdatedBy: string;
    lastUpdatedDate: Date | null;
    isDeleted: boolean;
}