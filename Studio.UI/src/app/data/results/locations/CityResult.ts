import { Guid } from "guid-typescript";
import { BaseResult } from "../base/BaseResult";
import { LocationResult } from "./LocationResult";
import { CountryResult } from "./CountryResult";

export interface CityResult extends BaseResult{
    cityName: string;
    countryId: Guid;
    country: CountryResult;
    locations: LocationResult[];
}