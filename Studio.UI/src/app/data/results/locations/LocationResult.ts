import { Guid } from "guid-typescript";
import { BaseResult } from "../base/BaseResult";
import { EventResult } from "../events/EventResult";
import { CityResult } from "./CityResult";

export interface LocationResult extends BaseResult{
    locationName: string;
    cityId: Guid;
    city: CityResult;
    events: EventResult[];
}