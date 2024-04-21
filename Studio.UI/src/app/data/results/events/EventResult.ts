import { Guid } from "guid-typescript";
import { WeddingResult } from "../weddings/WeddingResult";
import { LocationResult } from "../locations/LocationResult";
import { PhotoResult } from "../photos/PhotoResult";
import { ServiceResult } from "../services/ServiceResult";
import { BaseResult } from "../base/BaseResult";

export interface EventResult extends BaseResult{
    eventTitle: string;
    eventDescription?: string | null;
    weddingId?: Guid | null;
    locationId?: Guid | null;
    status?: string | null;
    wedding?: WeddingResult | null;
    location?: LocationResult | null;
    photos: PhotoResult[];
    services: ServiceResult[];
}